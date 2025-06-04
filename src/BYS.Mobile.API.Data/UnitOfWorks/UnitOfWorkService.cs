using BYS.Mobile.API.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace BYS.Mobile.API.Data.UnitOfWorks;

/// <summary>
/// Đơn vị giao dịch (Unit-of-Work) gộp cả SQL Server (EF Core)
/// và MongoDB (nếu còn dùng). Hỗ trợ Begin / Commit / Rollback
/// cho SQL, kèm SaveChangesAsync.
/// </summary>
public sealed class UnitOfWorkService : IUnitOfWorkService, IAsyncDisposable
{
    private readonly ApplicationDbContext _dbContext;
    private IDbContextTransaction?        _sqlTx;

    public UnitOfWorkService(ApplicationDbContext dbContext) 
    {
        _dbContext   = dbContext;
    }

    public async Task BeginTransactionAsync(CancellationToken ct = default)
    {
        if (_sqlTx is null)
            _sqlTx = await _dbContext.Database.BeginTransactionAsync(ct);
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default) =>
        _dbContext.SaveChangesAsync(ct);

    public Task CommitAsync(CancellationToken ct = default) =>
        _sqlTx is null
            ? _dbContext.SaveChangesAsync(ct)            // auto-commit mode
            : CommitWithTransactionAsync(ct);

    public async Task CommitWithTransactionAsync(CancellationToken ct = default)
    {
        await _dbContext.SaveChangesAsync(ct);
        await _sqlTx!.CommitAsync(ct);
        await _sqlTx.DisposeAsync();
        _sqlTx = null;
    }

    public async Task RollbackAsync(CancellationToken ct = default)
    {
        if (_sqlTx is null) return;

        await _sqlTx.RollbackAsync(ct);
        await _sqlTx.DisposeAsync();
        _sqlTx = null;
    }

    public async ValueTask DisposeAsync()
    {
        if (_sqlTx is not null)
            await _sqlTx.DisposeAsync();

        await _dbContext.DisposeAsync();
    }
    
}
