# Probas.Aliyun.LogService

#### Description
源于阿里云日志服务.NET SDK

#### Software Architecture
Software architecture description

#### Install Nuget Package
```bash
dotnet add package Probas.Aliyun.LogService
```

#### Instructions(Usage)

1.  Configure in `Startup.cs`
```cs
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, builder) =>
                {
                    // Add log4net log extension
                    builder.AddLog4Net();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
```

2.  Modify `appsettings.json`
```json
{
  "AliSlsConfig": {
    "Endpoint": "*.log.aliyuncs.com",
    "AccessKey": "*",
    "SecretKey": "*",
    "Project": "*",
    "Logstore": "*"
  }
}

```

3.  Use, refer to sample
 ```cs
        // auto injection direct use
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILogServiceClient _client;
        private readonly AliSlsOptions _options;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILogServiceClient client, IOptions<AliSlsOptions> options)
        {
            _logger = logger;
            _client = client;
            _options = options.Value;
        }
 ```
