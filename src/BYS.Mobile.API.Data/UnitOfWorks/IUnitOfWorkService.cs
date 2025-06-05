using System;
using System.Threading;
using System.Threading.Tasks;

namespace BYS.Mobile.API.Data.UnitOfWorks
{
    public interface IUnitOfWorkService : IAsyncDisposable
    {
        /// <summary>
        /// Thực thi một khối lệnh nằm trong transaction.
        /// Toàn bộ sẽ được retry an toàn nếu lỗi transient xảy ra.
        /// </summary>
        Task ExecuteInTransactionAsync(Func<Task> action, CancellationToken cancellationToken = default);

        /// <summary>
        /// Giống như ExecuteInTransactionAsync nhưng trả về kết quả.
        /// </summary>
        Task<int> ExecuteInTransactionAsync(Func<Task<int>> func, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gọi SaveChangesAsync độc lập nếu không cần transaction.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}