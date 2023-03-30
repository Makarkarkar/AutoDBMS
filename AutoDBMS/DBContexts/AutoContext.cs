using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AutoDBMS;

public partial class AutoContext : DbContext
{
    public AutoContext()
    {
    }

    public AutoContext(DbContextOptions<AutoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("brand_pkey");

            entity.ToTable("brands");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('brand_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Country)
                .HasColumnType("character varying")
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Ignore(b => b.ObjectId);
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("model_pkey");

            entity.ToTable("models");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('model_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Brand).WithMany(p => p.Models)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_models_brands");
            entity.Ignore(b => b.ObjectId);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("vehicle_pkey");

            entity.ToTable("vehicles");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('vehicle_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.OwnerEmail)
                .HasColumnType("character varying")
                .HasColumnName("owner_email");
            entity.Property(e => e.RegNumber)
                .HasColumnType("character varying")
                .HasColumnName("reg_number");

            entity.HasOne(d => d.Model).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_vehicles_models");
            entity.Ignore(b => b.ObjectId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
