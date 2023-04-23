using Domain.Core.Interfaces;
using Infra.Services.Marketplace;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Services.Extension
{
    public static class InjectInfraServiceHelper
    {
        public static IServiceCollection InjectInfraService(this IServiceCollection services)
        {            
            services.AddScoped<IMarketplaceService, MarketplaceClient>();
            return services;
        }
    }
}
