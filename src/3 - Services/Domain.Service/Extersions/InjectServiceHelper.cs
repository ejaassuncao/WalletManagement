using Domain.Core.IServices;
using Service.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Service.Core.Extersions
{
    public static class InjectServiceHelper
    {
        public static IServiceCollection InjectService(this IServiceCollection services)
        {
            services.AddScoped<IWalletService, WalletService>();
            return services;
        }
    }
}
