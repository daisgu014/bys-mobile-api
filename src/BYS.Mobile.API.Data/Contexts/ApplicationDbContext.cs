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

    public virtual DbSet<ArpriceSheet> ArpriceSheets { get; set; }

    public virtual DbSet<ArpriceSheetItem> ArpriceSheetItems { get; set; }

    public virtual DbSet<Arproposal> Arproposals { get; set; }

    public virtual DbSet<ArproposalItem> ArproposalItems { get; set; }

    public virtual DbSet<IcmeasureUnit> IcmeasureUnits { get; set; }

    public virtual DbSet<Icproduct> Icproducts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Arcustomer>(entity =>
        {
            entity.HasKey(e => e.ArcustomerId).HasName("PK_Customer");

            entity.ToTable("ARCustomers", tb => tb.HasTrigger("TRG_InsertUpdateCustomer"));
        });
         modelBuilder.Entity<ArpriceSheetItem>(entity =>
        {
            entity.HasOne(d => d.FkArpriceSheet).WithMany(p => p.ArpriceSheetItems).HasConstraintName("FK_ARPriceSheetItems_ARPriceSheets");

            entity.HasOne(d => d.FkIcmeasureUnit).WithMany(p => p.ArpriceSheetItems).HasConstraintName("FK_ARPriceSheetItems_ICMeasureUnits");

            entity.HasOne(d => d.FkIcproduct).WithMany(p => p.ArpriceSheetItems).HasConstraintName("FK_ARPriceSheetItems_ICProducts");
        });

        modelBuilder.Entity<Arproposal>(entity =>
        {
            entity.HasKey(e => e.ArproposalId).HasName("PK_PriceList");
        });

        modelBuilder.Entity<ArproposalItem>(entity =>
        {
            entity.HasKey(e => e.ArproposalItemId).HasName("PK_PriceListDetails");

            entity.HasOne(d => d.FkArproposal).WithMany(p => p.ArproposalItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARProposalItems_ARProposals");

            entity.HasOne(d => d.FkIcmeasureUnit).WithMany(p => p.ArproposalItems).HasConstraintName("FK_ARProposalItems_ICMeasureUnits");

            entity.HasOne(d => d.FkIcproduct).WithMany(p => p.ArproposalItemFkIcproducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARProposalItems_ICProducts");

            entity.HasOne(d => d.FkIcsectionProduct).WithMany(p => p.ArproposalItemFkIcsectionProducts).HasConstraintName("FK_ARProposalItems_ICSectionProducts");
        });

        modelBuilder.Entity<Icproduct>(entity =>
        {
            entity.HasKey(e => e.IcproductId).HasName("PK_Item");

            entity.HasOne(d => d.FkIcproductBasicUnit).WithMany(p => p.IcproductFkIcproductBasicUnits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ICProducts_ICMeasureUnits");

            entity.HasOne(d => d.FkIcproductCarcass).WithMany(p => p.InverseFkIcproductCarcass).HasConstraintName("FK_ICProducts_ICProductCarcass");

            entity.HasOne(d => d.FkIcproductParent).WithMany(p => p.InverseFkIcproductParent).HasConstraintName("ICProducts_FK_ICProductParentID");

            entity.HasOne(d => d.FkIcproductPurchaseUnit).WithMany(p => p.IcproductFkIcproductPurchaseUnits).HasConstraintName("FK_ICProducts_ICMeasureUnits2");

            entity.HasOne(d => d.FkIcproductSaleUnit).WithMany(p => p.IcproductFkIcproductSaleUnits).HasConstraintName("FK_ICProducts_ICMeasureUnits1");
        });
      

    }
}