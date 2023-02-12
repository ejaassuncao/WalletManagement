using Domain.Core.IServices;
using Service.Core.Services;

namespace Domain.Commons
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
