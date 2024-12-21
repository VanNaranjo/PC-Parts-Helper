using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProjectDAL;

public partial class PCPartsContext : DbContext
{
    public PCPartsContext()
    {
    }

    public PCPartsContext(DbContextOptions<PCPartsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CPU> CPUs { get; set; }

    public virtual DbSet<CPUFan> CPUFans { get; set; }

    public virtual DbSet<GPU> GPUs { get; set; }

    public virtual DbSet<InternalStorage> InternalStorages { get; set; }

    public virtual DbSet<MotherBoard> MotherBoards { get; set; }

    public virtual DbSet<PowerSupply> PowerSupplies { get; set; }

    public virtual DbSet<RAM> RAMs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=PCPartsDb;Trusted_Connection=True;");
        optionsBuilder.UseLazyLoadingProxies(); // add this code and remove the lambda operator
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CPU>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CPU__3213E83F3563BA7E");

            entity.ToTable("CPU");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.boost_clock).HasColumnType("numeric(3, 1)");
            entity.Property(e => e.core_clock).HasColumnType("numeric(5, 3)");
            entity.Property(e => e.graphics)
                .HasMaxLength(23)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(49)
                .IsUnicode(false);
            entity.Property(e => e.price).HasColumnType("numeric(7, 2)");
            entity.Property(e => e.smt)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CPUFan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CPUFan__3213E83FB6365EE6");

            entity.ToTable("CPUFan");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.color)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(62)
                .IsUnicode(false);
            entity.Property(e => e.noise_level)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.price).HasColumnType("numeric(6, 2)");
            entity.Property(e => e.rpm)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GPU>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GPU__3213E83F9077DA51");

            entity.ToTable("GPU");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.chipset)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.color)
                .HasMaxLength(19)
                .IsUnicode(false);
            entity.Property(e => e.memory).HasColumnType("numeric(5, 3)");
            entity.Property(e => e.name)
                .HasMaxLength(130)
                .IsUnicode(false);
            entity.Property(e => e.price).HasColumnType("numeric(7, 2)");
        });

        modelBuilder.Entity<InternalStorage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Internal__3213E83F1C0C4FCD");

            entity.ToTable("InternalStorage");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e._interface)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("interface");
            entity.Property(e => e.capacity).HasColumnType("numeric(6, 1)");
            entity.Property(e => e.form_factor)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(84)
                .IsUnicode(false);
            entity.Property(e => e.price).HasColumnType("numeric(7, 2)");
            entity.Property(e => e.price_per_gb).HasColumnType("numeric(5, 3)");
            entity.Property(e => e.type)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MotherBoard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MotherBo__3213E83F0455ADF9");

            entity.ToTable("MotherBoard");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.color)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.form_factor)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(66)
                .IsUnicode(false);
            entity.Property(e => e.price).HasColumnType("numeric(7, 2)");
            entity.Property(e => e.socket)
                .HasMaxLength(27)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PowerSupply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PowerSup__3213E83F072D1ED1");

            entity.ToTable("PowerSupply");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.color)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.efficiency)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.modular)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(79)
                .IsUnicode(false);
            entity.Property(e => e.price).HasColumnType("numeric(6, 2)");
            entity.Property(e => e.type)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RAM>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RAM__3213E83F92158C78");

            entity.ToTable("RAM");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.cas_latency).HasColumnType("numeric(3, 1)");
            entity.Property(e => e.color)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.first_word_latency).HasColumnType("numeric(6, 3)");
            entity.Property(e => e.modules)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(146)
                .IsUnicode(false);
            entity.Property(e => e.price).HasColumnType("numeric(7, 2)");
            entity.Property(e => e.price_per_gb).HasColumnType("numeric(7, 3)");
            entity.Property(e => e.speed)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
