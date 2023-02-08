using Domain.Commons.Entity;
using Domain.Commons.Test;
using Domain.Commons.Validate;
using Domain.Core.Model;
using Domain.Core.Model.Actives;
using Domain.Core.Test.Mock;
using FluentAssertions;
using System;
using Xunit;
using Action = System.Action;

namespace Domain.Core.Test
{
    public class WalletTest
    {
        /// <summary>
        /// Crei uma carteira e adicionei dois ativos
        /// </summary>
        [Fact]
        public void CreateWallatSucess()
        {
            Action cenario = () => NewWallet();
            cenario.Should().NotThrow<Exception>();
        }

        /// <summary>
        /// verificando o total do patrimonio
        /// </summary>
        [Fact]
        public void TotalCostWallate()
        {
            Wallet wallet = NewWallet();
            double expect = 7280;
            Assert.Equal(expect, wallet.TotalCost());
        }

        /// <summary>
        /// Testa o custo total da carteria
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="unitCost"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(60, 16, 960)]
        [InlineData(50, 100, 5000)]
        public void SuccessTotalCost(int amount, double unitCost, double expected)
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
            var magazine = CompanyTest.GetMagazineLuizaMock();
            var broker = new Broker("Rico", "Rico", "21457878");

            wallet.Buy(new Actions(magazine, magazine.GettTiker()), amount, unitCost, DateTime.Now, user, broker);

            Assert.Equal(expected, wallet.TotalCost());
        }

        /// <summary>
        /// Testa a validaçõa da carteria onde venda não poder ser maior que a compra
        /// </summary>
        [Fact]
        public void SalesLargerBuyException()
        {
            Action cene = () =>
            {
                var user = UserTest.GetNewInstanceMock();
                var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
                var magazine = CompanyTest.GetMagazineLuizaMock();
                var broker = new Broker("Rico", "Rico", "21457878");

                wallet.Buy(new Actions(magazine, magazine.GettTiker()), 4, 10, DateTime.Now, user, broker); //40
                wallet.Buy(new Actions(magazine, magazine.GettTiker()), 5, 12.50, DateTime.Now, user, broker); //62.50

                wallet.Sale(new Actions(magazine, magazine.GettTiker()), 2, 8, DateTime.Now, user); //16
                wallet.Sale(new Actions(magazine, magazine.GettTiker()), 5, 7, DateTime.Now, user);// 35
                wallet.Sale(new Actions(magazine, magazine.GettTiker()), 10, 10, DateTime.Now, user);//100

                double expected = -48.50;

                Assert.Equal(expected, wallet.TotalCost());
            };

            cene.Should().Throw<ExceptionDomainValidation>().WithMessage(Wallet.MSG_SALES_LARGER_BUY);
        }

        /// <summary>
        /// Verifica se a quantidade total condiz com as compras e vendas da carteira
        /// </summary>
        [Fact]
        public void TotalAmountBuyAndSales()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
            var broker = new Broker("Rico", "Rico", "21457878");

            var magazineCompany = CompanyTest.GetMagazineLuizaMock();
            var petrobrasCompany = CompanyTest.GetPetrobras();

            var magazineActive = new Actions(magazineCompany, magazineCompany.GettTiker());
            var petrobrasActive = new Actions(petrobrasCompany, petrobrasCompany.GettTiker());

            //total 19
            wallet.Buy(magazineActive, 4, 10, DateTime.Now, user, broker);
            wallet.Buy(magazineActive, 5, 12.50, DateTime.Now, user, broker);
            wallet.Buy(petrobrasActive, 10, 10, DateTime.Now, user, broker);

            //total 7
            wallet.Sale(magazineActive, 2, 8, DateTime.Now, user);
            wallet.Sale(magazineActive, 5, 7, DateTime.Now, user);

            double expected = 12;

            Assert.Equal(expected, wallet.TotalAmount());
        }

        /// <summary>
        /// Verifica se a quantidade total condiz com as compras e vendas de um determinado ativo
        /// </summary>
        [Fact]
        public void TotalAmountBuyAndSalesByActive()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
            var broker = new Broker("Rico", "Rico", "21457878");

            var magazineCompany = CompanyTest.GetMagazineLuizaMock();
            var petrobrasCompany = CompanyTest.GetPetrobras();

            var magazineActive = new Actions(magazineCompany, magazineCompany.GettTiker());
            var petrobrasActive = new Actions(petrobrasCompany, petrobrasCompany.GettTiker());

            //total 19
            wallet.Buy(magazineActive, 4, 10, DateTime.Now, user, broker);
            wallet.Buy(magazineActive, 5, 12.50, DateTime.Now, user, broker);
            wallet.Buy(petrobrasActive, 10, 10, DateTime.Now, user, broker);

            //total 7
            wallet.Sale(magazineActive, 2, 8, DateTime.Now, user);
            wallet.Sale(magazineActive, 5, 7, DateTime.Now, user);

            double expected = 2;

            Assert.Equal(expected, wallet.TotalAmount(magazineActive));
        }

        /// <summary>
        /// Verifica se o total de custo condiz com as compras e vendas da carteira
        /// </summary>
        [Fact]
        public void TotalCostBuyAndSales()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
            var broker = new Broker("Rico", "Rico", "21457878");

            var magazineCompany = CompanyTest.GetMagazineLuizaMock();
            var petrobrasCompany = CompanyTest.GetPetrobras();

            var magazineActive = new Actions(magazineCompany, magazineCompany.GettTiker());
            var petrobrasActive = new Actions(petrobrasCompany, petrobrasCompany.GettTiker());

            //total 202,50
            wallet.Buy(magazineActive, 4, 10, DateTime.Now, user, broker);
            wallet.Buy(magazineActive, 5, 12.50, DateTime.Now, user, broker);
            wallet.Buy(petrobrasActive, 10, 10, DateTime.Now, user, broker);

            //total 51
            wallet.Sale(magazineActive, 2, 8, DateTime.Now, user);
            wallet.Sale(magazineActive, 5, 7, DateTime.Now, user);

            double expected = 151.50;

            Assert.Equal(expected, wallet.TotalCost());
        }

        /// <summary>
        /// Verifica se o total de custo condiz com as compras e vendas de um determinado ativo
        /// </summary>
        [Fact]
        public void TotalCostBuyAndSalesByActive()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
            var broker = new Broker("Rico", "Rico", "21457878");

            var magazineCompany = CompanyTest.GetMagazineLuizaMock();
            var petrobrasCompany = CompanyTest.GetPetrobras();

            var magazineActive = new Actions(magazineCompany, magazineCompany.GettTiker());
            var petrobrasActive = new Actions(petrobrasCompany, petrobrasCompany.GettTiker());

            //total 102,5 de magalu
            wallet.Buy(magazineActive, 4, 10, DateTime.Now, user, broker);
            wallet.Buy(magazineActive, 5, 12.50, DateTime.Now, user, broker);
            wallet.Buy(petrobrasActive, 10, 10, DateTime.Now, user, broker);

            //total 51
            wallet.Sale(magazineActive, 2, 8, DateTime.Now, user);
            wallet.Sale(magazineActive, 5, 7, DateTime.Now, user);

            double expected = 51.50;

            Assert.Equal(expected, wallet.TotalCost(magazineActive));
        }

        /// <summary>
        /// Testa função que verifica se um determinado Existe em carteira
        /// </summary>
        [Fact]
        public void ExisteActive()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
            var magazine = CompanyTest.GetMagazineLuizaMock();
            var action = new Actions(magazine, magazine.GettTiker());
            var broker = new Broker("Rico", "Rico", "21457878");

            wallet.Buy(action, 5, 12.50, DateTime.Now, user, broker);

            var expected = true;

            Assert.Equal(expected, wallet.ExistsActive(action));
        }

        /// <summary>
        /// Testa função que verifica se um determinado NÂO existe em carteira
        /// </summary>
        [Fact]
        public void NotExisteActive()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");

            var magazine = CompanyTest.GetMagazineLuizaMock();
            var action = new Actions(magazine, magazine.GettTiker());

            var expected = false;

            Assert.Equal(expected, wallet.ExistsActive(action));
        }

        /// <summary>
        /// Quero saber quando eu tenho de patrimonio caso vender minhas açõoes
        /// </summary>
        [Theory]
        [InlineData(9.90, 23.50)]
        [InlineData(7.80, 23.80)]
        [InlineData(7.50, 22.85)]
        [InlineData(8.90, 22.60)]
        public void GetPatrimony(double countingMagazine, double countingPetrobras)
        {
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
            var user = UserTest.GetNewInstanceMock();
            var magazineCompany = CompanyTest.GetMagazineLuizaMock();
            var petrobrasCompany = CompanyTest.GetPetrobras();

            var broker = new Broker("Rico", "Rico", "21457878");

            var magazineActive = new Actions(magazineCompany, magazineCompany.GettTiker());
            magazineActive.UpdateCounting(countingMagazine);

            var petrobrasActive = new Actions(petrobrasCompany, petrobrasCompany.GettTiker());
            petrobrasActive.UpdateCounting(countingPetrobras);

            //total 102,5 de magalu
            wallet.Buy(magazineActive, 4, 10, DateTime.Now, user, broker);
            wallet.Buy(magazineActive, 5, 12.50, DateTime.Now, user, broker);
            wallet.Buy(magazineActive, 10, 8, DateTime.Now, user, broker);

            wallet.Buy(petrobrasActive, 8, 12.50, DateTime.Now, user, broker);
            wallet.Buy(petrobrasActive, 15, 8, DateTime.Now, user, broker);

            var result = Math.Round(wallet.GetPatrimony(), 2);
            double expected = Math.Round((19 * countingMagazine) + (23 * countingPetrobras), 2);

            Assert.Equal(expected, result);

        }

        /// <summary>
        /// Quero saber se estou com lucro / prejuizo de patrimonio
        /// </summary>
        [Theory]
        [InlineData(9.90, 23.50)]
        [InlineData(7.80, 23.80)]
        [InlineData(7.50, 22.85)]
        [InlineData(8.90, 22.60)]
        public void GetProfit(double countingMagazine, double countingPetrobras)
        {
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
            var user = UserTest.GetNewInstanceMock();
            var magazineCompany = CompanyTest.GetMagazineLuizaMock();
            var petrobrasCompany = CompanyTest.GetPetrobras();

            var broker = new Broker("Rico", "Rico", "21457878");

            var magazineActive = new Actions(magazineCompany, magazineCompany.GettTiker());
            magazineActive.UpdateCounting(countingMagazine);

            var petrobrasActive = new Actions(petrobrasCompany, petrobrasCompany.GettTiker());
            petrobrasActive.UpdateCounting(countingPetrobras);

            //total 102,5 de magalu
            wallet.Buy(magazineActive, 4, 10, DateTime.Now, user, broker);
            wallet.Buy(magazineActive, 5, 12.50, DateTime.Now, user, broker);
            wallet.Buy(magazineActive, 10, 8, DateTime.Now, user, broker);

            wallet.Buy(petrobrasActive, 8, 12.50, DateTime.Now, user, broker);
            wallet.Buy(petrobrasActive, 15, 8, DateTime.Now, user, broker);

            var result = wallet.GetProfit();

            var patrimony = wallet.GetPatrimony();
            var totalCost = wallet.TotalCost();

            var expected = (patrimony - totalCost);

            Assert.Equal(Math.Round(expected, 2), Math.Round(result, 2));

        }

        /// <summary>
        /// cria uma carteria com compras e Vendas
        /// </summary>
        /// <returns></returns>
        public static Wallet NewWallet()
        {
            User user = UserTest.GetNewInstanceMock();
            var magazine = CompanyTest.GetMagazineLuizaMock();
            var wallet = new Wallet(user, "Ativos BR");
            var broker = new Broker("Rico", "Rico", "21457878");

            wallet.Buy(new Actions(magazine, magazine.GettTiker(EnumActionTypeTicker.ON)), 60, 16.00, DateTime.Now, user, broker);

            var petrobras = CompanyTest.GetPetrobras();
            wallet.Buy(new Actions(petrobras, petrobras.GettTiker(EnumActionTypeTicker.PN)), 60, 22.00, DateTime.Now, user, broker);

            var habt11 = CompanyTest.GetHabt11();
            wallet.Buy(new Fiis(habt11, habt11.GettTiker()), 50, 100.00, DateTime.Now, user, broker);

            return wallet;
        }
    }
}