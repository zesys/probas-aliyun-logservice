using Aliyun.Api.LogService.Domain.Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Probas.Aliyun.LogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServiceSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILogServiceClient _client;
        private readonly AliSlsOptions _options;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILogServiceClient client, IOptions<AliSlsOptions> options)
        {
            _logger = logger;
            _client = client;
            _options = options.Value;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var contents = new Dictionary<string, string> {
                { "content", "This is the log write test." }
            };
            var logs = new List<LogInfo>
            {
                new LogInfo
                {
                    Time = DateTimeOffset.Now,
                    Contents = contents
                }
            };
            var tags = new Dictionary<string, string>();
            var source = "netapi";
            var logGroupInfo = new LogGroupInfo { Logs = logs, LogTags = tags, Topic = "test-topic", Source = source };
            var request = new PostLogsRequest(_options.Logstore, logGroupInfo);
            var result = _client.PostLogStoreLogsAsync(request).Result;

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
