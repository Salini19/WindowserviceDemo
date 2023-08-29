namespace WindowserviceDemo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                string filename = @"C:\Users\salini.s\source\repos\WindowserviceDemo\WindowserviceDemo" + DateTime.Now.ToString("ddmmmyyyy")+".txt";
                if (!System.IO.File.Exists(filename))
                {
                    System.IO.File.Create(filename);
                }
                System.IO.File.AppendAllText(filename, "Added at " + DateTime.Now.ToString("hhmmss"));
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}