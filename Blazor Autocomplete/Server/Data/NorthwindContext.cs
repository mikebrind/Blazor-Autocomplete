using Blazor_Autocomplete.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Autocomplete.Server.Data;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext()
    {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; } = null!;
    public virtual DbSet<Customer> Customers { get; set; } = null!;
    public virtual DbSet<Employee> Employees { get; set; } = null!;
    public virtual DbSet<InternationalOrder> InternationalOrders { get; set; } = null!;
    public virtual DbSet<Order> Orders { get; set; } = null!;
    public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    public virtual DbSet<PreviousEmployee> PreviousEmployees { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<Region> Regions { get; set; } = null!;
    public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
    public virtual DbSet<Territory> Territories { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("data source=data\\northwind.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.CategoryName, "IX_Categories_CategoryName");

            entity.Property(e => e.CategoryId)
                .HasColumnType("integer")
                .HasColumnName("CategoryID");

            entity.Property(e => e.CategoryName).HasColumnType("nvarchar(15)");

            entity.Property(e => e.Description).HasColumnType("nvarchar");

            entity.Property(e => e.Picture).HasColumnType("varbinary");
        });

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

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.LastName, "IX_Employees_LastName");

            entity.HasIndex(e => e.PostalCode, "IX_Employees_PostalCode");

            entity.Property(e => e.EmployeeId)
                .HasColumnType("integer")
                .HasColumnName("EmployeeID");

            entity.Property(e => e.Address).HasColumnType("nvarchar(60)");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");

            entity.Property(e => e.City).HasColumnType("nvarchar(15)");

            entity.Property(e => e.Country).HasColumnType("nvarchar(15)");

            entity.Property(e => e.Extension).HasColumnType("nvarchar(4)");

            entity.Property(e => e.FirstName).HasColumnType("nvarchar(10)");

            entity.Property(e => e.HireDate).HasColumnType("datetime");

            entity.Property(e => e.HomePhone).HasColumnType("nvarchar(24)");

            entity.Property(e => e.LastName).HasColumnType("nvarchar(20)");

            entity.Property(e => e.Notes).HasColumnType("ntext");

            entity.Property(e => e.Photo).HasColumnType("image");

            entity.Property(e => e.PhotoPath).HasColumnType("nvarchar(255)");

            entity.Property(e => e.PostalCode).HasColumnType("nvarchar(10)");

            entity.Property(e => e.Region).HasColumnType("nvarchar(15)");

            entity.Property(e => e.Title).HasColumnType("nvarchar(30)");

            entity.Property(e => e.TitleOfCourtesy).HasColumnType("nvarchar(25)");

            entity.HasMany(d => d.Territories)
                .WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeesTerritory",
                    l => l.HasOne<Territory>().WithMany().HasForeignKey("TerritoryId").OnDelete(DeleteBehavior.ClientSetNull),
                    r => r.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId").OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("EmployeeId", "TerritoryId");

                        j.ToTable("EmployeesTerritories");

                        j.IndexerProperty<long>("EmployeeId").HasColumnType("integer").HasColumnName("EmployeeID");

                        j.IndexerProperty<long>("TerritoryId").HasColumnType("integer").HasColumnName("TerritoryID");
                    });
        });

        modelBuilder.Entity<InternationalOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.Property(e => e.OrderId)
                .HasColumnType("integer")
                .ValueGeneratedNever()
                .HasColumnName("OrderID");

            entity.Property(e => e.CustomsDescription).HasColumnType("nvarchar(100)");

            entity.Property(e => e.ExciseTax).HasColumnType("money");

            entity.HasOne(d => d.Order)
                .WithOne(p => p.InternationalOrder)
                .HasForeignKey<InternationalOrder>(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerID");

            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomersOrders");

            entity.HasIndex(e => e.EmployeeId, "IX_Orders_EmployeeID");

            entity.HasIndex(e => e.EmployeeId, "IX_Orders_EmployeesOrders");

            entity.HasIndex(e => e.OrderDate, "IX_Orders_OrderDate");

            entity.HasIndex(e => e.ShipPostalCode, "IX_Orders_ShipPostalCode");

            entity.HasIndex(e => e.ShippedDate, "IX_Orders_ShippedDate");

            entity.Property(e => e.OrderId)
                .HasColumnType("integer")
                .HasColumnName("OrderID");

            entity.Property(e => e.CustomerId)
                .HasColumnType("nchar(5)")
                .HasColumnName("CustomerID");

            entity.Property(e => e.EmployeeId)
                .HasColumnType("integer")
                .HasColumnName("EmployeeID");

            entity.Property(e => e.Freight)
                .HasColumnType("money")
                .HasDefaultValueSql("0");

            entity.Property(e => e.OrderDate).HasColumnType("datetime");

            entity.Property(e => e.RequiredDate).HasColumnType("datetime");

            entity.Property(e => e.ShipAddress).HasColumnType("nvarchar(60)");

            entity.Property(e => e.ShipCity).HasColumnType("nvarchar(15)");

            entity.Property(e => e.ShipCountry).HasColumnType("nvarchar(15)");

            entity.Property(e => e.ShipName).HasColumnType("nvarchar(40)");

            entity.Property(e => e.ShipPostalCode).HasColumnType("nvarchar(10)");

            entity.Property(e => e.ShipRegion).HasColumnType("nvarchar(15)");

            entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId);

            entity.HasIndex(e => e.OrderDetailsId, "IX_OrderDetails_OrderDetailsID")
                .IsUnique();

            entity.HasIndex(e => e.OrderId, "IX_OrderDetails_OrderID");

            entity.HasIndex(e => e.OrderId, "IX_OrderDetails_OrdersOrder_Details");

            entity.HasIndex(e => e.ProductId, "IX_OrderDetails_ProductID");

            entity.HasIndex(e => e.ProductId, "IX_OrderDetails_ProductsOrder_Details");

            entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");

            entity.Property(e => e.Discount).HasColumnType("real");

            entity.Property(e => e.OrderId)
                .HasColumnType("integer")
                .HasColumnName("OrderID");

            entity.Property(e => e.ProductId)
                .HasColumnType("integer")
                .HasColumnName("ProductID");

            entity.Property(e => e.Quantity)
                .HasColumnType("smallint")
                .HasDefaultValueSql("1");

            entity.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasDefaultValueSql("0");

            entity.HasOne(d => d.Order)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PreviousEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.EmployeeId)
                .HasColumnType("integer")
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");

            entity.Property(e => e.Address).HasColumnType("nvarchar(60)");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");

            entity.Property(e => e.City).HasColumnType("nvarchar(15)");

            entity.Property(e => e.Country).HasColumnType("nvarchar(15)");

            entity.Property(e => e.Extension).HasColumnType("nvarchar(4)");

            entity.Property(e => e.FirstName).HasColumnType("nvarchar(10)");

            entity.Property(e => e.HireDate).HasColumnType("datetime");

            entity.Property(e => e.HomePhone).HasColumnType("nvarchar(24)");

            entity.Property(e => e.LastName).HasColumnType("nvarchar(20)");

            entity.Property(e => e.Notes).HasColumnType("ntext");

            entity.Property(e => e.Photo).HasColumnType("image");

            entity.Property(e => e.PhotoPath).HasColumnType("nvarchar(255)");

            entity.Property(e => e.PostalCode).HasColumnType("nvarchar(10)");

            entity.Property(e => e.Region).HasColumnType("nvarchar(15)");

            entity.Property(e => e.Title).HasColumnType("nvarchar(30)");

            entity.Property(e => e.TitleOfCourtesy).HasColumnType("nvarchar(25)");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoriesProducts");

            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryID");

            entity.HasIndex(e => e.ProductName, "IX_Products_ProductName");

            entity.HasIndex(e => e.SupplierId, "IX_Products_SupplierID");

            entity.HasIndex(e => e.SupplierId, "IX_Products_SuppliersProducts");

            entity.Property(e => e.ProductId)
                .HasColumnType("integer")
                .HasColumnName("ProductID");

            entity.Property(e => e.CategoryId)
                .HasColumnType("integer")
                .HasColumnName("CategoryID");

            entity.Property(e => e.Discontinued)
                .HasColumnType("bit")
                .HasDefaultValueSql("0");

            entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

            entity.Property(e => e.ProductName).HasColumnType("nvarchar(40)");

            entity.Property(e => e.QuantityPerUnit).HasColumnType("nvarchar(20)");

            entity.Property(e => e.ReorderLevel)
                .HasColumnType("smallint")
                .HasDefaultValueSql("0");

            entity.Property(e => e.SupplierId)
                .HasColumnType("integer")
                .HasColumnName("SupplierID");

            entity.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasDefaultValueSql("0");

            entity.Property(e => e.UnitsInStock)
                .HasColumnType("smallint")
                .HasDefaultValueSql("0");

            entity.Property(e => e.UnitsOnOrder)
                .HasColumnType("smallint")
                .HasDefaultValueSql("0");

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Supplier)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.Property(e => e.RegionId)
                .HasColumnType("integer")
                .ValueGeneratedNever()
                .HasColumnName("RegionID");

            entity.Property(e => e.RegionDescription).HasColumnType("nvarchar(50)");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasIndex(e => e.CompanyName, "IX_Suppliers_CompanyName");

            entity.HasIndex(e => e.PostalCode, "IX_Suppliers_PostalCode");

            entity.Property(e => e.SupplierId)
                .HasColumnType("integer")
                .HasColumnName("SupplierID");

            entity.Property(e => e.Address).HasColumnType("nvarchar(60)");

            entity.Property(e => e.City).HasColumnType("nvarchar(15)");

            entity.Property(e => e.CompanyName).HasColumnType("nvarchar(40)");

            entity.Property(e => e.ContactName).HasColumnType("nvarchar(30)");

            entity.Property(e => e.ContactTitle).HasColumnType("nvarchar(30)");

            entity.Property(e => e.Country).HasColumnType("nvarchar(15)");

            entity.Property(e => e.Fax).HasColumnType("nvarchar(24)");

            entity.Property(e => e.HomePage).HasColumnType("ntext");

            entity.Property(e => e.Phone).HasColumnType("nvarchar(24)");

            entity.Property(e => e.PostalCode).HasColumnType("nvarchar(10)");

            entity.Property(e => e.Region).HasColumnType("nvarchar(15)");
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.Property(e => e.TerritoryId)
                .HasColumnType("integer")
                .ValueGeneratedNever()
                .HasColumnName("TerritoryID");

            entity.Property(e => e.RegionId)
                .HasColumnType("integer")
                .HasColumnName("RegionID");

            entity.Property(e => e.TerritoryDescription).HasColumnType("nvarchar(50)");

            entity.HasOne(d => d.Region)
                .WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
