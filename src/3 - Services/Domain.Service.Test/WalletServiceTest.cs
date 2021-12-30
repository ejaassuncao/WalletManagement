using System;
using Xunit;
using Domain.Core.Model;
using Domain.Core.Test;
using FluentAssertions;
using Service.Core;

namespace Domain.Service.Test
{
    public class WalletServiceTest
    {
        /// <summary>
        /// Visualizar valor total investidos em Grupos de ativos
        /// Posso ver em percentual ou preço
        /// </summary>
        [Fact]
        public void VisualizationGroupTypeActives()
        {
            Action action = () =>
            {
                Wallet wallate = WalletTest.NewWallet();
                var service = new WalletService();
                var totalPriceTypeActives = service.GetTotalPriceTypeActives(wallate);
            };

            action.Should().NotThrow<Exception>();
        }
        
    }
}
