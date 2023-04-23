using Domain.Core.Model.Enumerables;
using Infra.Ef.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef.InitBaseBase
{
    public class DbInitializer
    {
        public DbInitializer(ModelBuilder modelBuilder)
        {

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
            var sector3 = new TbSector
            {
                Id = Guid.NewGuid(),
                Name = "Eletrico",
                UserCreated = tbuser.Id
            };
            modelBuilder.Entity<TbSector>().HasData(sector, sector2, sector3);

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

            var company3 = new TbCompany
            {
                Id = Guid.NewGuid(),
                CNPJ = "48.566.523/0001-01",
                Name = "Taeesa transmissão Eletrica",
                SetorId = sector3.Id,
                UserCreated = tbuser.Id,
            };
            modelBuilder.Entity<TbCompany>().HasData(company, company2, company3);


            //action
            var active = new TbActive
            {
                Id = Guid.NewGuid(),
                Category = EnumCategory.ACTION,
                CompanyId = company.Id,
                Price = 0,
                Ticker = "MGLU3",
                UserCreated = tbuser.Id,
            };
            var active2 = new TbActive
            {
                Id = Guid.NewGuid(),
                Category = EnumCategory.ACTION,
                CompanyId = company2.Id,
                Price = 0,
                Ticker = "BBAS3",
                UserCreated = tbuser.Id,
            };

            var active3 = new TbActive
            {
                Id = Guid.NewGuid(),
                Category = EnumCategory.ACTION,
                CompanyId = company3.Id,
                Price = 0,
                Ticker = "TAEE3",
                UserCreated = tbuser.Id,
            };
            modelBuilder.Entity<TbActive>().HasData(active, active2, active3);

            //ActivesOfCompany
            var tbActivesOfCompany = new TbActivesOfCompany
            {
                Id = Guid.NewGuid(),
                UserCreated = tbuser.Id,
                ActiveId = active.Id,
                Amount = 50,
                UnitCost = (decimal)22.50,
                BrokerId = broker.Id,
                Operation = EnumOperationWallet.BUY,
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
                BrokerId = broker.Id,
                Operation = EnumOperationWallet.BUY,
                UserId = tbuser.Id,
                WalletId = wallet.Id
            };

            var tbActivesOfCompany3 = new TbActivesOfCompany
            {
                Id = Guid.NewGuid(),
                UserCreated = tbuser.Id,
                ActiveId = active3.Id,
                Amount = (decimal)600,
                UnitCost = (decimal)13.50,
                BrokerId = broker.Id,
                Operation = EnumOperationWallet.BUY,
                UserId = tbuser.Id,
                WalletId = wallet.Id
            };

            modelBuilder.Entity<TbActivesOfCompany>().HasData(tbActivesOfCompany, tbActivesOfCompany2, tbActivesOfCompany3);

        }
    }
}
