using Domain.Models.Settings;
using Infra.Services.Extension;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Services.Test
{
    public class Startup
    {   
        public void ConfigureServices(IServiceCollection services)
        {
            var setting = new Settings();
            setting.BrApi= new BrApi { Token = "9EQfpwBFDFKNJpun6g1NCL" };

            services.AddSingleton(setting);
            InjectInfraServiceHelper.InjectInfraService(services);
        }
    }
}
