using Domain.Models.Settings;
using Infra.Ef.Extension;
using Infra.Repository.Extension;
using Infra.Services.Extension;
using Service.Core.Extersions;

namespace Presentation.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

            builder.Services.AddCors();
            builder.Services.AddControllers();            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));  

            Settings settings = new Settings
            {               
                BrApi = new BrApi { Token = builder.Configuration.GetSection("Settings:BrApi:Token").Value},
                ConnectionStrings = new ConnectionStrings
                {
                    DefaultConnection = builder.Configuration.GetSection("Settings:ConnectionStrings:DefaultConnection").Value
                }
            };

            builder.Services.AddSingleton(settings);
            builder.Services.InjectRepository();
            builder.Services.InjectService();
            builder.Services.InjectInfraService();

            builder.Services.AddAutoMapper(typeof(AutoMapping));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.InitializeDatabase();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors(
               options => options.AllowAnyOrigin().AllowAnyMethod()
            );   


            app.Run();
        }
    }
}