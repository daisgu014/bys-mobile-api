using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Shared.Providers.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Contexts;

public class ApplicationDbContext : DbContext
{
    private readonly ICoreProvider _coreProvider;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        ICoreProvider coreProvider) : base(options)
    {
        _coreProvider = coreProvider;
    }
    public virtual DbSet<Arcustomer> Arcustomers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Arcustomer>(entity =>
        {
            entity.HasKey(e => e.ArcustomerId).HasName("PK_Customer");

            entity.ToTable("ARCustomers", tb => tb.HasTrigger("TRG_InsertUpdateCustomer"));
        });


    }
}