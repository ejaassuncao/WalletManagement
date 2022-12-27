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


        [Theory]
        [InlineData(60, 16, 960)]
        [InlineData(50, 100, 5000)]
        public void SuccessTotalCost(int amount, double unitCost, double expected)
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
            var magazine = CompanyTest.GetMagazineLuizaMock();

            wallet.Buy(new Actions(magazine, magazine.GettTiker()), amount, unitCost, DateTime.Now, user);

            Assert.Equal(expected, wallet.TotalCost());
        }

        [Fact]
        public void SalesLargerBuyException()
        {
            Action cene = () => { 
                var user = UserTest.GetNewInstanceMock();
                var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
                var magazine = CompanyTest.GetMagazineLuizaMock();

                wallet.Buy(new Actions(magazine, magazine.GettTiker()), 4, 10, DateTime.Now, user); //40
                wallet.Buy(new Actions(magazine, magazine.GettTiker()), 5, 12.50, DateTime.Now, user); //62.50

                wallet.Sale(new Actions(magazine, magazine.GettTiker()), 2, 8, DateTime.Now, user); //16
                wallet.Sale(new Actions(magazine, magazine.GettTiker()), 5, 7, DateTime.Now, user);// 35
                wallet.Sale(new Actions(magazine, magazine.GettTiker()), 10, 10, DateTime.Now, user);//100

                double expected = -48.50;

                Assert.Equal(expected, wallet.TotalCost());
            };

            cene.Should().Throw<ExceptionDomainValidation>().WithMessage(Wallet.MSG_SALES_LARGER_BUY);
        }

        [Fact]
        public void TotalAmountBuyAndSales()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
           
            var magazineCompany = CompanyTest.GetMagazineLuizaMock();
            var petrobrasCompany = CompanyTest.GetPetrobras();

            var magazineActive = new Actions(magazineCompany, magazineCompany.GettTiker());
            var petrobrasActive = new Actions(petrobrasCompany, petrobrasCompany.GettTiker());

            //total 19
            wallet.Buy(magazineActive, 4, 10, DateTime.Now, user);
            wallet.Buy(magazineActive, 5, 12.50, DateTime.Now, user);
            wallet.Buy(petrobrasActive, 10, 10, DateTime.Now, user);

            //total 7
            wallet.Sale(magazineActive, 2, 8, DateTime.Now, user);
            wallet.Sale(magazineActive, 5, 7, DateTime.Now, user);

            double expected = 12;

            Assert.Equal(expected, wallet.TotalAmount());
        }

        [Fact]
        public void TotalAmountBuyAndSalesByActive()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");

            var magazineCompany = CompanyTest.GetMagazineLuizaMock();
            var petrobrasCompany = CompanyTest.GetPetrobras();

            var magazineActive = new Actions(magazineCompany, magazineCompany.GettTiker());
            var petrobrasActive = new Actions(petrobrasCompany, petrobrasCompany.GettTiker());

            //total 19
            wallet.Buy(magazineActive, 4, 10, DateTime.Now, user);
            wallet.Buy(magazineActive, 5, 12.50, DateTime.Now, user);
            wallet.Buy(petrobrasActive, 10, 10, DateTime.Now, user);

            //total 7
            wallet.Sale(magazineActive, 2, 8, DateTime.Now, user);
            wallet.Sale(magazineActive, 5, 7, DateTime.Now, user);

            double expected = 2;

            Assert.Equal(expected, wallet.TotalAmount(magazineActive));
        }


        [Fact]
        public void TotalCostBuyAndSales()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
           
            var magazineCompany = CompanyTest.GetMagazineLuizaMock();
            var petrobrasCompany = CompanyTest.GetPetrobras();

            var magazineActive = new Actions(magazineCompany, magazineCompany.GettTiker());
            var petrobrasActive = new Actions(petrobrasCompany, petrobrasCompany.GettTiker());

            //total 202,50
            wallet.Buy(magazineActive, 4, 10, DateTime.Now, user);
            wallet.Buy(magazineActive, 5, 12.50, DateTime.Now, user);
            wallet.Buy(petrobrasActive, 10, 10, DateTime.Now, user);

            //total 51
            wallet.Sale(magazineActive, 2, 8, DateTime.Now, user);
            wallet.Sale(magazineActive, 5, 7, DateTime.Now, user);

            double expected = 151.50;

            Assert.Equal(expected, wallet.TotalCost());
        }


        [Fact]
        public void TotalCostBuyAndSalesByActive()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");       

            var magazineCompany = CompanyTest.GetMagazineLuizaMock();
            var petrobrasCompany = CompanyTest.GetPetrobras();

            var magazineActive = new Actions(magazineCompany, magazineCompany.GettTiker());
            var petrobrasActive = new Actions(petrobrasCompany, petrobrasCompany.GettTiker());

            //total 102,5 de magalu
            wallet.Buy(magazineActive, 4, 10, DateTime.Now, user);
            wallet.Buy(magazineActive, 5, 12.50, DateTime.Now, user);
            wallet.Buy(petrobrasActive, 10, 10, DateTime.Now, user);

            //total 51
            wallet.Sale(magazineActive, 2, 8, DateTime.Now, user);
            wallet.Sale(magazineActive, 5, 7, DateTime.Now, user);

            double expected = 51.50;

            Assert.Equal(expected, wallet.TotalCost(magazineActive));
        }

        [Fact]
        public void ExisteActive()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");
            var magazine = CompanyTest.GetMagazineLuizaMock();
            var action = new Actions(magazine, magazine.GettTiker());

            wallet.Buy(action, 5, 12.50, DateTime.Now, user); 

            var expected = true;              
       
            Assert.Equal(expected, wallet.ExistActive(action));
        }

        [Fact]
        public void NotExisteActive()
        {
            var user = UserTest.GetNewInstanceMock();
            var wallet = new Wallet(UserTest.GetNewInstanceMock(), "Ativos BR");

            var magazine = CompanyTest.GetMagazineLuizaMock();
            var action = new Actions(magazine, magazine.GettTiker());
               
            var expected = false;

            Assert.Equal(expected, wallet.ExistActive(action));
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
