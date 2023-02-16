using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ef.Context
{
    public  static class InicializeDataBaseHelper
    {
        public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDBContext>();

                //facilita mas nem tanto
                context.Database.Migrate();  //so cria o banco, leva em consideração a migração já feitas, como se esse comando fosse apenas o: "update-database"

                //modo primitivo**** localhost isso seria legal
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated(); //Cria o banco e gerar as migrações, porem não gera o historico de versão migrações

                //DbInitializer.Initialize(context); //Popula algumas tabelas

                return app;
            }
        }
    }
}
