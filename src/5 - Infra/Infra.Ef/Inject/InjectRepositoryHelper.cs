﻿using Domain.core.IRepository;
using Infra.Ef.Context;
using Infra.Ef.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ef.Inject
{
    public static class InjectRepositoryHelper
    {
        public static IServiceCollection InjectRepository(this IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddScoped<IWalletRespository, WalletRespository>();
            return services;
        }
    }
}