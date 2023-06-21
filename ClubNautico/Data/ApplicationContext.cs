using System;
using System.Collections.Generic;
using ClubNautico.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.Data;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barco> Barcos { get; set; }

    public virtual DbSet<Socio> Socios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Barcos_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.IdSocio).HasColumnName("id_socio");
            entity.Property(e => e.Modelo)
                .HasColumnType("character varying")
                .HasColumnName("modelo");

            entity.HasOne(d => d.IdSocioNavigation).WithMany(p => p.Barcos)
                .HasForeignKey(d => d.IdSocio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_socio");
        });

        modelBuilder.Entity<Socio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Socio_pkey");

            entity.ToTable("Socio");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasColumnType("character varying")
                .HasColumnName("apellido");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
