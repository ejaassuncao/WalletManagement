using System;
using System.Collections.Generic;
using Infra.Ef.EntityData;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef.Context;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbSector> TbSectors { get; set; }
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbSector>(entity =>
        {
            entity.HasKey(e => e.SctId).HasName("sct_id");

            entity.ToTable("tb_sector", tb => tb.HasComment("abbreviation: sct\r\nDescription: table sector"));

            entity.Property(e => e.SctId)
                .ValueGeneratedNever()
                .HasComment("pk table")
                .HasColumnName("sct_Id");
            entity.Property(e => e.CidUserCreated).HasColumnName("CIdUserCreated");
            entity.Property(e => e.CidUserLastUpdate).HasColumnName("CIdUserLastUpdate");
            entity.Property(e => e.SctDcreated).HasColumnName("sct_DCreated");
            entity.Property(e => e.SctName)
                .HasMaxLength(60)
                .HasComment("sector name")
                .HasColumnName("sct_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
