using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WorkshopDatabaseFirst.Models;

namespace WorkshopDatabaseFirst.Data;

public partial class ContactAddressDbContext : DbContext
{
    public ContactAddressDbContext()
    {
    }

    public ContactAddressDbContext(DbContextOptions<ContactAddressDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactAdrress> ContactAdrresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ContactAddressDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Addresse__091C2A1B8493F718");

            entity.Property(e => e.AddressId)
                .ValueGeneratedNever()
                .HasColumnName("AddressID");
            entity.Property(e => e.Street).HasMaxLength(100);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contacts__5C6625BBCAE3BB8B");

            entity.Property(e => e.ContactId)
                .ValueGeneratedNever()
                .HasColumnName("ContactID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<ContactAdrress>(entity =>
        {
            entity.HasKey(e => e.ContactAddressId).HasName("PK__ContactA__FF47E2943C2D940D");

            entity.Property(e => e.ContactAddressId)
                .ValueGeneratedNever()
                .HasColumnName("ContactAddressID");
            entity.Property(e => e.FkAddressId).HasColumnName("FkAddressID");
            entity.Property(e => e.FkContactId).HasColumnName("FkContactID");

            entity.HasOne(d => d.FkAddress).WithMany(p => p.ContactAdrresses)
                .HasForeignKey(d => d.FkAddressId)
                .HasConstraintName("FK__ContactAd__FkAdd__4F7CD00D");

            entity.HasOne(d => d.FkContact).WithMany(p => p.ContactAdrresses)
                .HasForeignKey(d => d.FkContactId)
                .HasConstraintName("FK__ContactAd__FkCon__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
