using BYS.Mobile.API.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BYS.Mobile.API.Data.Extensions;

public static class DatabaseContextExtension
{
    public static void AddSqlServerDbContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        // get connection string
        var connectionStr = configuration.GetConnectionString("DefaultConnection")
                            ?? throw new InvalidOperationException("DefaultConnection is not configured.");


        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionStr, sqlOpt =>
            {
                // Cấu hình retry khi gặp lỗi transient
                sqlOpt.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
            }));
    }
}