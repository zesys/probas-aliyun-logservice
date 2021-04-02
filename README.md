# Probas.Aliyun.LogService

#### 介绍
源于阿里云日志服务.NET SDK

#### 软件架构
软件架构说明

#### 安装Nuget包
```bash
dotnet add package Probas.Aliyun.LogService
```

#### 使用说明(配置)

1.  在 `Startup.cs` 进行如下配置
```cs
        public void ConfigureServices(IServiceCollection services)
        {
            // 从配置文件读取LogService相关配置，并注入使用
            services.AddAliLogService();
        }
```
2.  修改 `appsettings.json`
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
3.  使用，参考Sample
 ```cs
        // 自动注入直接使用
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
