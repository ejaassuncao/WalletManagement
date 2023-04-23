using Presentation.WorkerService.Configs;

IHost host = Host.CreateDefaultBuilder(args)
    //.UseWindowsService()
    .ConfigureLogging((hostingContext, config) =>
    {
        config.AddLog4Net("log4net.config", true);
        config.SetMinimumLevel(LogLevel.Information);
        //config.SetMinimumLevel(LogLevel.Debug);

    })
      .ConfigureServices((hostContext, services) =>
      {   
          IConfiguration configuration = hostContext.Configuration;
          AppSettings settings = configuration.GetSection("AppSettings").Get<AppSettings>();
          services.AddSingleton(settings);

          // Inicialize  Quartz            
          QuartzConfigurator.InitQuartz(hostContext, services);
      })
    .Build();

host.Run();
