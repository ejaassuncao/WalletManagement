using Domain.core.IRepository;
using Infra.Ef.Repository;

namespace Domain.Commons
{
    public static class InjectRepositoryHelper
    {
        public static IServiceCollection InjectRepository(this IServiceCollection services)
        {
            services.AddScoped<IWalletRespository, WalletRespository>();
            return services;
        }
    }
}
