using MongoDB.Driver;

namespace BYS.Mobile.API.Data.UnitOfWorks
{
    public interface IUnitOfWorkService
    {
        /// <summary> Bắt đầu một transaction. Idempotent. </summary>
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary> Ghi thay đổi vào DbContext (chưa commit transaction). </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary> Commit transaction sau khi SaveChanges. </summary>
        Task CommitAsync(CancellationToken cancellationToken = default);

        /// <summary> Rollback (Abort) transaction nếu có lỗi. </summary>
        Task RollbackAsync(CancellationToken cancellationToken = default);

        Task CommitWithTransactionAsync(CancellationToken ct = default);
    }
}
