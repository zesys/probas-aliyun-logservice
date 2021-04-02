using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Probas.Aliyun.LogService;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SlsServiceCollectionExtensions
    {
        public static IServiceCollection AddAliLogService(this IServiceCollection services, string confName = "AliSlsConfig")
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>().GetSection(confName);
            AliSlsOptions options = new();
            services.Configure<AliSlsOptions>(configuration);
            configuration.Bind(options);

            var client = LogServiceClientBuilders.HttpBuilder
                .Endpoint(options.Endpoint, options.Project)
                .Credential(options.AccessKey, options.SecretKey)
                .Build();

            services.AddSingleton<ILogServiceClient>(client);
            return services;
        }
    }
}
