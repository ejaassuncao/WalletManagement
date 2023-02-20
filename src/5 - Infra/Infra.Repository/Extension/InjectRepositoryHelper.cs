using Domain.core.IRepository;
using Infra.Repository.Context;
using Infra.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Repository.Extension
{
    public static class InjectRepositoryHelper
    {
        public static IServiceCollection InjectRepository(this IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddScoped<IWalletRespository, WalletRespository>();
            return services;
        }
    }
}
