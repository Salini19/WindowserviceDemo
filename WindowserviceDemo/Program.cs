using Serilog;
using WindowserviceDemo;

var progdata = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(Path.Combine(progdata, "WindowserviceDemo", "servicelog.txt"))
    .CreateLogger();

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options=> { options.ServiceName = "My Worker Service"; })
    .UseSerilog()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
