using Domain.core.IRepository;
using Infra.Ef.Context;
using Infra.Ef.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Repository.Extension
{
    public static class InjectRepositoryHelper
    {
        public static IServiceCollection InjectRepository(this IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:DefaultConnection")
                       // .EnableSensitiveDataLogging()
                );
            services.AddScoped<IWalletRespository, WalletRespository>();
            return services;
        }
    }
}
