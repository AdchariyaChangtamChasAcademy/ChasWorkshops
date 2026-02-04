using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WS_EcommerceClient.Models;

public partial class EcommerceDbContext : DbContext
{
    public EcommerceDbContext()
    {
    }

    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

    public virtual DbSet<OrderHeader> OrderHeaders { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    public virtual DbSet<OrdersByCity> OrdersByCities { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAbovePricePoint> ProductAbovePricePoints { get; set; }

    public virtual DbSet<UniqueCustomer> UniqueCustomers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=EcommerceDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8F07214CB");

            entity.ToTable("Customer", tb => tb.HasTrigger("trg_RemoveCustomer"));

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CustomerOrders");

            entity.Property(e => e.Customer).HasMaxLength(101);
        });

        modelBuilder.Entity<OrderHeader>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__OrderHea__C3905BCF0AC8A4D8");

            entity.ToTable("OrderHeader", tb =>
                {
                    tb.HasTrigger("trg_InsertOrderHeader");
                    tb.HasTrigger("trg_UpdateOrderDate");
                });

            entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.HasOne(d => d.FkCustomer).WithMany(p => p.OrderHeaders)
                .HasForeignKey(d => d.FkCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderHeader_Customer");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(e => e.OrderLineId).HasName("PK__OrderLin__29068A108B05758F");

            entity.ToTable("OrderLine");

            entity.Property(e => e.OrderLineId).ValueGeneratedNever();

            entity.HasOne(d => d.FkOrder).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.FkOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderLine_OrderHeader");

            entity.HasOne(d => d.FkProduct).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.FkProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderLine_Product");
        });

        modelBuilder.Entity<OrdersByCity>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrdersByCity");

            entity.Property(e => e.City).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD528BF645");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<ProductAbovePricePoint>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ProductAbovePricePoint");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<UniqueCustomer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UniqueCustomers");

            entity.Property(e => e.FullName).HasMaxLength(101);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
