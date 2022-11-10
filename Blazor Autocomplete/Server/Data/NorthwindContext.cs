using BlazorAutocomplete.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorAutocomplete.Server.Data;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext()
    {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.City, "IX_Customers_City");

            entity.HasIndex(e => e.CompanyName, "IX_Customers_CompanyName");

            entity.HasIndex(e => e.PostalCode, "IX_Customers_PostalCode");

            entity.HasIndex(e => e.Region, "IX_Customers_Region");

            entity.Property(e => e.CustomerId)
                .HasColumnType("nchar(5)")
                .HasColumnName("CustomerID");

            entity.Property(e => e.Address).HasColumnType("nvarchar(60)");

            entity.Property(e => e.City).HasColumnType("nvarchar(15)");

            entity.Property(e => e.CompanyName).HasColumnType("nvarchar(40)");

            entity.Property(e => e.ContactName).HasColumnType("nvarchar(30)");

            entity.Property(e => e.ContactTitle).HasColumnType("nvarchar(30)");

            entity.Property(e => e.Country).HasColumnType("nvarchar(15)");

            entity.Property(e => e.Fax).HasColumnType("nvarchar(24)");

            entity.Property(e => e.Phone).HasColumnType("nvarchar(24)");

            entity.Property(e => e.PostalCode).HasColumnType("nvarchar(10)");

            entity.Property(e => e.Region).HasColumnType("nvarchar(15)");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
