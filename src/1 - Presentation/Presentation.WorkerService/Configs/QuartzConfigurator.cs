using log4net;
using Quartz;

namespace Presentation.WorkerService.Configs
{
    public static class QuartzConfigurator
    {
        private static readonly ILog _loggerFactory = LogManager.GetLogger(typeof(Program));

        public static void AddJobAndTrigger<T>(
           this IServiceCollectionQuartzConfigurator quartz,
           IConfiguration config)
           where T : IJob
        {
            // Use the name of the IJob as the appsettings.json key
            string jobName = typeof(T).Name;

            // Try and load the schedule from configuration
            var configKey = $"AppSettings:CronExpression";
            var cronSchedule = config[configKey];

            // Some minor validation
            if (string.IsNullOrEmpty(cronSchedule))
            {
                throw new Exception($"No Quartz.NET Cron schedule found for job in configuration at {configKey}");
            }

            // register the job as before
            var jobKey = new JobKey(jobName);
            quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

            quartz.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity(jobName + "-trigger")
                .WithCronSchedule(cronSchedule)); // use the schedule from configuration
        }

        public static void InitQuartz(HostBuilderContext hostContext, IServiceCollection services)
        {
            try
            {
                // Add the required Quartz.NET services
                services.AddQuartz(q =>
                {
                    // Use a Scoped container to create jobs. I'll touch on this later
                    q.UseMicrosoftDependencyInjectionScopedJobFactory();

                    //Register the job, loading the schedule from configuration                  
                    q.AddJobAndTrigger<Worker>(hostContext.Configuration);
                });

                services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            }
            catch (Exception exp)
            {
                _loggerFactory.Error(exp.Message);
            }
        }
    }
}
