using Infra.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Repository.Extension
{
    public static class InicializeDataBaseHelper
    {
        public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                try
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<DataBaseContext>();

                    //facilita mas nem tanto               
                    context.Database.Migrate();  //so cria o banco, leva em consideração a migração já feitas, como se esse comando fosse apenas o: "update-database"

                    //modo primitivo**** localhost isso seria legal
                    //context.Database.EnsureDeleted();
                    //context.Database.EnsureCreated(); //Cria o banco e gerar as migrações, porem não gera o historico de versão migrações

                    //DbInitializer.Initialize(context); //Popula algumas tabelas
                }
                catch
                {
                    //Não faz nada se der erro
                }
                return app;
            }
        }
    }
}
