using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace wpf_Hianyzasok_2024.Models;

public partial class HianyzasContext : DbContext
{
    public HianyzasContext()
    {
    }

    public HianyzasContext(DbContextOptions<HianyzasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hianyza> Hianyzas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=hianyzas;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Hianyza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("hianyzas");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ElsoNap).HasColumnType("int(11)");
            entity.Property(e => e.MulasztottOrak).HasColumnType("int(11)");
            entity.Property(e => e.Nev).HasMaxLength(255);
            entity.Property(e => e.Osztaly).HasMaxLength(255);
            entity.Property(e => e.UtolsoNap).HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
