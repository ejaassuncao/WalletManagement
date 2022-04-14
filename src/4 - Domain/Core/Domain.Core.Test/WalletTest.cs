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

        public static Wallet NewWallet()
        {
            var wallet = new Wallet(1, "Ativos BR");

            var magazine = CompanyTest.GetMagazineLuiza();

            wallet.Buy(new Actions(magazine, magazine.GettTiker(EnumActionTypeTicker.Ordinaria), 60, 16, DateTime.Now));

            var petrobras = CompanyTest.GetPetrobras();
            wallet.Buy(new Actions(petrobras, petrobras.GettTiker(EnumActionTypeTicker.Preferencial), 60, 22, DateTime.Now));

            var habt11 = CompanyTest.GetHabt11();
            wallet.Buy(new Fiis(habt11, habt11.GettTiker(),  50, 100, DateTime.Now));

            return wallet;
        }        
    }
}
