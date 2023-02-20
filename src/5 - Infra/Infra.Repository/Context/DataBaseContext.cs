
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

    public virtual DbSet<Broker> Brokers { get; set; }

    public virtual DbSet<NewTable> NewTables { get; set; }

    public virtual DbSet<TbSector> TbSectors { get; set; }

    public virtual DbSet<TbWallet> TbWallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.ApplyConfiguration(new Configurations.BrokerConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.NewTableConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TbSectorConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TbWalletConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
