using System;
using System.Collections.Generic;
using Infra.Ef.EntityData;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef.Context;

public partial class AppDBContext_Remove : DbContext
{
    public AppDBContext_Remove()
    {
    }

    public AppDBContext_Remove(DbContextOptions<AppDBContext_Remove> options)
        : base(options)
    {
    }

    public virtual DbSet<TbSector> TbSectors { get; set; }

    public virtual DbSet<TbWallet> TbWallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbSector>(entity =>
        {
            entity.HasKey(e => e.SctId).HasName("sct_id");

            entity.ToTable("tb_sector", tb => tb.HasComment("abbreviation: sct\r\nDescription: table sector"));

            entity.Property(e => e.SctId)
                .ValueGeneratedNever()
                .HasComment("pk table");
            entity.Property(e => e.SctName).HasComment("sector name");
        });

        modelBuilder.Entity<TbWallet>(entity =>
        {
            entity.ToTable("tb_wallet", tb => tb.HasComment("abbreviation:  wal\r\nDescription: tables wallet"));

            entity.Property(e => e.WalId).HasComment("PK table");
            entity.Property(e => e.WalName).HasComment("Name wallet");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
