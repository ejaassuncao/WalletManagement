using Infra.Repository.Context.Configurations;
using Infra.Repository.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace Infra.Repository.Context;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbSector> TbSectors { get; set; }

    public virtual DbSet<TbWallet> TbWallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=Infra.DataBase;Integrated Security=true");

            modelBuilder.ApplyConfiguration(new TbSectorConfiguration());
            modelBuilder.ApplyConfiguration(new TbWalletConfiguration());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
