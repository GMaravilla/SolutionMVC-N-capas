using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class MvcPruebasContext : DbContext
{
    public MvcPruebasContext()
    {
    }

    public MvcPruebasContext(DbContextOptions<MvcPruebasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Balero> Baleros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Balero>(entity =>
        {
            entity.HasKey(e => e.IdBaleros).HasName("PK__Baleros__AA2084F9A2EC0CED");

            entity.Property(e => e.Codigo)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("Fecha_Create");
            entity.Property(e => e.Marca)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(5, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
