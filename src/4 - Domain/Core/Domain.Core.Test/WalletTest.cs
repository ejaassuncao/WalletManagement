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
            var wallet = new Wallet("Ativos BR");

            var magazine = CompanyTest.GetMagazineLuiza();          
            wallet.Actives.Add(new Actions(magazine, magazine.GettTiker(), 60, 16));

            var petrobras = CompanyTest.GetPetrobras();
            wallet.Actives.Add(new Actions(petrobras, petrobras.GettTiker(EnumTypeTicker.Preferencial), 60, 22));

            var habt11 = CompanyTest.GetHabt11();
            wallet.Actives.Add(new Fiis(habt11, habt11.GettTiker(),  50, 100));

            return wallet;
        }        
    }
}
