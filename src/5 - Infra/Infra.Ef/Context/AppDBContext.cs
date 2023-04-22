using Domain.Commons.Entity;
using Domain.Core.Model;
using Domain.Core.Model.Actives;
using Domain.Core.Model.Enumerables;
using Infra.Ef.DataModel;
using Microsoft.EntityFrameworkCore;
using System;

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

    public virtual DbSet<TbActive> TbActives { get; set; }

    public virtual DbSet<TbCompany> TbCompanys { get; set; }

    public virtual DbSet<TbSector> TbSectors { get; set; }

    public virtual DbSet<TbBroker> TbBrokers { get; set; }

     public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbActivesOfCompany> TbActivesOfCompanys { get; set; }

    public virtual DbSet<TbWallet> TbWallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ////tbuser
        var userId = Guid.NewGuid();
        var tbuser = new TbUser
        {
            Id = userId,
            Login = "elton",
            Password = "123456",
            UserCreated = userId
        };
        modelBuilder.Entity<TbUser>().HasData(tbuser);

        //sector
        var sector = new TbSector
        {
            Id = Guid.NewGuid(),
            Name = "Varejo",
            UserCreated = tbuser.Id
        };
        var sector2 = new TbSector
        {
            Id = Guid.NewGuid(),
            Name = "Financeiro",
            UserCreated = tbuser.Id
        };
        modelBuilder.Entity<TbSector>().HasData(sector, sector2);

        //broker
        var brokerId = Guid.NewGuid();
        var broker = new TbBroker
        {
            Id = brokerId,
            CorporateName = "Itau",
            CNPJ = "48.537.525/0001-01",
            FantasyName = "Itau investimentos",
            UserCreated = userId
        };
        modelBuilder.Entity<TbBroker>().HasData(broker);

        //wallet
        var wallet = new TbWallet
        {
            Id = Guid.NewGuid(),
            BrokerId = brokerId,           
            Name = "Minha Carteira",
            OwnerId = userId,
        };
        modelBuilder.Entity<TbWallet>().HasData(new[] { wallet });


        //company
        var company = new TbCompany
        {
            Id = Guid.NewGuid(),
            CNPJ = "48.537.555/0001-01",
            Name = "Magazine Luiza",
            SetorId = sector.Id,
            UserCreated = tbuser.Id,
        };
        var company2 = new TbCompany
        {
            Id = Guid.NewGuid(),
            CNPJ = "48.537.523/0001-01",
            Name = "Banco do Brasil",
            SetorId = sector2.Id,
            UserCreated = tbuser.Id,
        };
        modelBuilder.Entity<TbCompany>().HasData(company, company2);

        //action
        var active = new TbActive
        {
            Id = Guid.NewGuid(),
            Category = EnumCategory.ACTION,
            CompanyId = company.Id,
            Price = (decimal)10.80,
            Ticker = "MGLU3",
            UserCreated = tbuser.Id,
        };
        var active2 = new TbActive
        {
            Id = Guid.NewGuid(),
            Category = EnumCategory.ACTION,
            CompanyId = company2.Id,
            Price = (decimal)40.70,
            Ticker = "BBAS3",
            UserCreated = tbuser.Id,
        };
        modelBuilder.Entity<TbActive>().HasData(active, active2);

        //ActivesOfCompany
        var tbActivesOfCompany = new TbActivesOfCompany
        {
            Id = Guid.NewGuid(),
            UserCreated = tbuser.Id,
            ActiveId = active.Id,
            Amount = 50,
            UnitCost = (decimal)22.50,
            BrokerId = broker.Id,
            Operation = EnumOperationWallet.SALES,
            UserId = tbuser.Id,
            WalletId = wallet.Id
        };
        var tbActivesOfCompany2 = new TbActivesOfCompany
        {
            Id = Guid.NewGuid(),
            UserCreated = tbuser.Id,
            ActiveId = active2.Id,
            Amount = 200,
            UnitCost = (decimal)43.50,
            BrokerId   = broker.Id,
            Operation = EnumOperationWallet.SALES,
            UserId = tbuser.Id,
            WalletId = wallet.Id
        };
        modelBuilder.Entity<TbActivesOfCompany>().HasData(tbActivesOfCompany, tbActivesOfCompany2);
    }
}
