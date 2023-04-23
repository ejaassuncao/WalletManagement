using Presentation.WorkerService.Configs;
using Quartz;

namespace Presentation.WorkerService
{
    [DisallowConcurrentExecution]
    public class Worker : IJob
    {
        private readonly ILogger<Worker> _logger;
        private readonly AppSettings _appSettings;

        public Worker(ILogger<Worker> logger, AppSettings appSettings)
        {
            _logger = logger;
            this._appSettings = appSettings;
        }

       
        public async Task Execute(IJobExecutionContext context)
        {         
            try
            {
                _logger.LogInformation($"========================INICIO DA STEP 04 {DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss")}========================");
                using var client = new HttpClient();
                var json = await client.GetStringAsync(_appSettings.ApiExecute);
                _logger.LogInformation($"{json}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            _logger.LogInformation($"========================FIM DA STEP 04 {DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss")}========================");
        }
    }
}