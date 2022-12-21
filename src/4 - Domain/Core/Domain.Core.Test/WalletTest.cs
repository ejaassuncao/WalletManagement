using Domain.Commons.Entity;
using Domain.Commons.Test;
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


        [Theory]
        [InlineData(60, 16, 960)]
        [InlineData(50, 100, 5000)]
        public static void SuccessTotalCost(int amount, double unitCost, double expected)
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
            var magazine = CompanyTest.GetMagazineLuizaMock();

            wallet.Buy(new Actions(magazine, magazine.GettTiker()), amount, unitCost, DateTime.Now, user);

            Assert.Equal(expected, wallet.TotalCost());
        }


        public static Wallet NewWallet()
        {
            User user = UserTest.GetNewInstanceMock();

            var wallet = new Wallet(user, "Ativos BR");

            var magazine = CompanyTest.GetMagazineLuizaMock();

            wallet.Buy(new Actions(magazine, magazine.GettTiker(EnumActionTypeTicker.ON)), 60, 16.00, DateTime.Now, user);

            var petrobras = CompanyTest.GetPetrobras();
            wallet.Buy(new Actions(petrobras, petrobras.GettTiker(EnumActionTypeTicker.PN)), 60, 22.00, DateTime.Now, user);

            var habt11 = CompanyTest.GetHabt11();
            wallet.Buy(new Fiis(habt11, habt11.GettTiker()), 50, 100.00, DateTime.Now, user);
                    
            return wallet;
        }
    }
}
