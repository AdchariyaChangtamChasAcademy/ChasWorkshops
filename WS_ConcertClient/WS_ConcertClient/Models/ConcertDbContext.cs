using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WS_ConcertClient.Models;

public partial class ConcertDbContext : DbContext
{
    public ConcertDbContext()
    {
    }

    public ConcertDbContext(DbContextOptions<ConcertDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Concert> Concerts { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ConcertDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("PK__Artist__25706B501C8134CC");

            entity.ToTable("Artist");

            entity.Property(e => e.ArtistId).ValueGeneratedNever();
            entity.Property(e => e.ArtistName).HasMaxLength(100);
            entity.Property(e => e.Genre).HasMaxLength(50);
        });

        modelBuilder.Entity<Concert>(entity =>
        {
            entity.HasKey(e => e.ConcertId).HasName("PK__Concert__06ED37AC88FBCD30");

            entity.ToTable("Concert");

            entity.Property(e => e.ConcertId).ValueGeneratedNever();

            entity.HasOne(d => d.FkArtist).WithMany(p => p.Concerts)
                .HasForeignKey(d => d.FkArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Concert_Artist");

            entity.HasOne(d => d.FkVenue).WithMany(p => p.Concerts)
                .HasForeignKey(d => d.FkVenueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Concert_Venue");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__712CC6073AA43C6B");

            entity.ToTable("Ticket");

            entity.Property(e => e.TicketId).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.FkConcert).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.FkConcertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Ticket_Concert");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.VenueId).HasName("PK__Venue__3C57E5F2D9B32C41");

            entity.ToTable("Venue");

            entity.Property(e => e.VenueId).ValueGeneratedNever();
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.VenueName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
