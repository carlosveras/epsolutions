using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EPSolutions.Models;

public partial class TreinamentoContext : DbContext
{
    public TreinamentoContext()
    {
    }

    public TreinamentoContext(DbContextOptions<TreinamentoContext> options)
        : base(options)
    {
    }

    public DbSet<ItensRomaneio> ItensRomaneio { get; set; }


    public DbSet<Romaneio> Romaneios { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Treinamento;User Id=sa;Password=123456;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItensRomaneio>(entity =>
        {
            entity.HasKey(e => new { e.Id });
            entity.HasKey(e => new { e.Id, e.IdRomaneio });

            entity.Property(e => e.DescrVolumes).HasMaxLength(30);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NrCaixa).HasMaxLength(10);

            entity.HasOne(d => d.IdRomaneioNavigation).WithMany()
                .HasForeignKey(d => d.IdRomaneio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItensRomaneio_Romaneio");
        });

        modelBuilder.Entity<Romaneio>(entity =>
        {
            entity.ToTable("Romaneio");

            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.NomeCliente).HasMaxLength(50);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
