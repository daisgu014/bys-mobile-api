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

    public virtual DbSet<IcproductAttribute> IcproductAttributes { get; set; }
    public virtual DbSet<Aduser> Adusers { get; set; }

    public virtual DbSet<AduserGroup> AduserGroups { get; set; }

    public virtual DbSet<Hremployee> Hremployees { get; set; }

     public virtual DbSet<Genumbering> Genumberings { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



        modelBuilder.Entity<Arcustomer>(entity =>
        {
            entity.HasKey(e => e.ArcustomerId).HasName("PK_Customer");

            entity.ToTable("ARCustomers", tb => tb.HasTrigger("TRG_InsertUpdateCustomer"));
        });

        modelBuilder.Entity<ArpriceSheet>(entity =>
        {
            entity.HasOne(d => d.FkArcustomer).WithMany(p => p.ArpriceSheets).HasConstraintName("FK_ARPriceSheets_ARCustomers");
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

            entity.HasOne(d => d.FkArcustomer).WithMany(p => p.Arproposals).HasConstraintName("FK_ARProposals_ARCustomers");
        });

        modelBuilder.Entity<ArproposalItem>(entity =>
        {
            entity.HasKey(e => e.ArproposalItemId).HasName("PK_PriceListDetails");

            entity.HasOne(d => d.FkArproposal).WithMany(p => p.ArproposalItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARProposalItems_ARProposals");

            entity.HasOne(d => d.FkIcmeasureUnit).WithMany(p => p.ArproposalItems).HasConstraintName("FK_ARProposalItems_ICMeasureUnits");

            entity.HasOne(d => d.FkIcproductAttributeColor).WithMany(p => p.ArproposalItemFkIcproductAttributeColors).HasConstraintName("FK_ARProposalItems_ICProductAttributes2");

            entity.HasOne(d => d.FkIcproductAttributeWoodType).WithMany(p => p.ArproposalItemFkIcproductAttributeWoodTypes).HasConstraintName("FK_ARProposalItems_ICProductAttributes1");

            entity.HasOne(d => d.FkIcproduct).WithMany(p => p.ArproposalItemFkIcproducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARProposalItems_ICProducts");

            entity.HasOne(d => d.FkIcsectionProduct).WithMany(p => p.ArproposalItemFkIcsectionProducts).HasConstraintName("FK_ARProposalItems_ICSectionProducts");
        });

        modelBuilder.Entity<Icproduct>(entity =>
        {
            entity.HasKey(e => e.IcproductId).HasName("PK_Item");

            entity.HasOne(d => d.FkArcustomer).WithMany(p => p.Icproducts).HasConstraintName("ICProducts_FK_ARCustomerID");

            entity.HasOne(d => d.FkIcprodAttPackingMaterialSize).WithMany(p => p.IcproductFkIcprodAttPackingMaterialSizes).HasConstraintName("FK_ICProducts_ICProductAttributes5");

            entity.HasOne(d => d.FkIcprodAttPackingMaterialSpeciality).WithMany(p => p.IcproductFkIcprodAttPackingMaterialSpecialities).HasConstraintName("FK_ICProducts_ICProductAttributes4");

            entity.HasOne(d => d.FkIcprodAttPackingMaterialWeightPerVolume).WithMany(p => p.IcproductFkIcprodAttPackingMaterialWeightPerVolumes).HasConstraintName("FK_ICProducts_ICProductAttributes6");

            entity.HasOne(d => d.FkIcproductAttributeColor).WithMany(p => p.IcproductFkIcproductAttributeColors).HasConstraintName("FK_ICProducts_ICProductAttributes2");

            entity.HasOne(d => d.FkIcproductAttributeFinishing).WithMany(p => p.IcproductFkIcproductAttributeFinishings).HasConstraintName("FK_ICProducts_ICProductAttributes3");

            entity.HasOne(d => d.FkIcproductAttributeQuality).WithMany(p => p.IcproductFkIcproductAttributeQualities).HasConstraintName("ICProducts_FK_ICProductAttributeQualityID");

            entity.HasOne(d => d.FkIcproductAttributeSemiProductSpeciality).WithMany(p => p.IcproductFkIcproductAttributeSemiProductSpecialities).HasConstraintName("FK_ICProducts_ICProductAttributes7");

            entity.HasOne(d => d.FkIcproductAttributeWoodType).WithMany(p => p.IcproductFkIcproductAttributeWoodTypes).HasConstraintName("FK_ICProducts_ICProductAttributes1");

            entity.HasOne(d => d.FkIcproductBasicUnit).WithMany(p => p.IcproductFkIcproductBasicUnits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ICProducts_ICMeasureUnits");

            entity.HasOne(d => d.FkIcproductCarcass).WithMany(p => p.InverseFkIcproductCarcass).HasConstraintName("FK_ICProducts_ICProductCarcass");

            entity.HasOne(d => d.FkIcproductParent).WithMany(p => p.InverseFkIcproductParent).HasConstraintName("ICProducts_FK_ICProductParentID");

            entity.HasOne(d => d.FkIcproductPurchaseUnit).WithMany(p => p.IcproductFkIcproductPurchaseUnits).HasConstraintName("FK_ICProducts_ICMeasureUnits2");

            entity.HasOne(d => d.FkIcproductSaleUnit).WithMany(p => p.IcproductFkIcproductSaleUnits).HasConstraintName("FK_ICProducts_ICMeasureUnits1");

            entity.HasOne(d => d.FkIcproductThickGroup).WithMany(p => p.IcproductFkIcproductThickGroups).HasConstraintName("FK_ICProducts_ICProductAttributes8");
        });

        modelBuilder.Entity<IcproductAttribute>(entity =>
        {
            entity.HasOne(d => d.FkArcustomer).WithMany(p => p.IcproductAttributes).HasConstraintName("FK_ICProductAttributes_ARCustomers");
        });
        modelBuilder.Entity<Aduser>(entity =>
        {
            entity.HasKey(e => e.AduserId).HasName("PK_User");

            entity.HasOne(d => d.AduserGroup).WithMany(p => p.Adusers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ADUsers_ADUserGroups");

            entity.HasOne(d => d.FkHremployee).WithMany(p => p.Adusers).HasConstraintName("FK_ADUsers_HREmployees");
        });

        modelBuilder.Entity<AduserGroup>(entity =>
        {
            entity.HasKey(e => e.AduserGroupId).HasName("PK_UserGroup");
        });

        modelBuilder.Entity<Hremployee>(entity =>
        {
            entity.ToTable("HREmployees", tb => tb.HasTrigger("TRG_InsertUpdateEmployee"));
        });
        modelBuilder.Entity<Genumbering>(entity =>
        {
            entity.Property(e => e.GenumberingDesc)
                .HasDefaultValueSql("((0))")
                .HasComment("0:Auto\r\n1:Manual");
        });
    }
}