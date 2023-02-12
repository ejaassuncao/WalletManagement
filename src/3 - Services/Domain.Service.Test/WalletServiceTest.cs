using Domain.Core.IServices;
using Domain.Core.Model;
using Domain.Core.Test;
using FluentAssertions;
using Service.Core;
using System;
using Xunit;

namespace Domain.Service.Test
{
    public class WalletServiceTest
    {
        private readonly IWalletService walletService;

        public WalletServiceTest(IWalletService walletService)
        {
            this.walletService = walletService;
        }


        /// <summary>
        /// Visualizar valor total investidos em Grupos de ativos
        /// Posso ver em percentual ou pre�o
        /// </summary>
        [Fact]
        public void VisualizationGroupTypeActives()
        {
            Action action = () =>
            {
                Wallet wallate = WalletTest.NewWallet();              
                var totalPriceTypeActives = walletService.GetTotalPriceTypeActives(wallate);
            };

            action.Should().NotThrow<Exception>();
        }
        
    }
}
