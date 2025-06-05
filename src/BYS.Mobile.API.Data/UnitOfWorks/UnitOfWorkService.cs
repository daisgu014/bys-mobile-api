using BYS.Mobile.API.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BYS.Mobile.API.Data.UnitOfWorks;

/// <summary>
/// Đơn vị giao dịch (Unit-of-Work) hỗ trợ SQL Server (EF Core)
/// Bao gồm Begin, Commit, Rollback, SaveChangesAsync.
/// Với SqlServerRetryingExecutionStrategy tích hợp sẵn.
/// </summary>
public sealed class UnitOfWorkService : IUnitOfWorkService, IAsyncDisposable
{
    private readonly ApplicationDbContext _dbContext;
    private IDbContextTransaction? _sqlTx;

    public UnitOfWorkService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default) =>
        _dbContext.SaveChangesAsync(ct);

    public async Task ExecuteInTransactionAsync(Func<Task> action, CancellationToken ct = default)
    {
        var strategy = _dbContext.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);

            try
            {
                await action();
                await _dbContext.SaveChangesAsync(ct);

                await transaction.CommitAsync(ct);
            }
            catch
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
        });
    }

    // Optional for simple use cases
    public async Task<int> ExecuteInTransactionAsync(Func<Task<int>> func, CancellationToken ct = default)
    {
        var strategy = _dbContext.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);

            try
            {
                var result = await func();
                await transaction.CommitAsync(ct);
                return result;
            }
            catch
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
        });
    }

    public async ValueTask DisposeAsync()
    {
        if (_sqlTx is not null)
            await _sqlTx.DisposeAsync();

        await _dbContext.DisposeAsync();
    }
}
