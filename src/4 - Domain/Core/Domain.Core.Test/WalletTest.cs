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
            Wallet wallet =  NewWallet();
            double expect = 7280;
            Assert.Equal(expect, wallet.TotalCost());
        }

        public static Wallet NewWallet()
        {
            var wallet = new Wallet(1, "Ativos BR");

            var magazine = CompanyTest.GetMagazineLuiza();

            wallet.Buy(new Actions(magazine, magazine.GettTiker(EnumActionTypeTicker.Ordinaria), 60, 16, DateTime.Now)); 

            var petrobras = CompanyTest.GetPetrobras();
            wallet.Buy(new Actions(petrobras, petrobras.GettTiker(EnumActionTypeTicker.Preferencial), 60, 22, DateTime.Now));

            var habt11 = CompanyTest.GetHabt11();
            wallet.Buy(new Fiis(habt11, habt11.GettTiker(),  50, 100, DateTime.Now));

            //poderi ser assim?
            //wallat.Buy(magazine.BuildAction(EnumActionTypeTicker.Ordinaria), 20, 12.50, DateTime.Now);
            //wallat.Sale(magazine.BuildAction(EnumActionTypeTicker.Ordinaria), 20, 11.50, DateTime.Now.AddDays(1));


            return wallet;
        }        
    }
}
