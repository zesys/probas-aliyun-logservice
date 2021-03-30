using Aliyun.Api.LogService.Infrastructure.Protocol.Http;

namespace Probas.Aliyun.LogService
{
    /// <summary>
    /// <see cref="ILogServiceClient"/> 实现类构建器。
    /// </summary>
    public static class LogServiceClientBuilders
    {
        /// <summary>
        /// 实现 HTTP 协议的构建器。
        /// </summary>
        public static HttpLogServiceClientBuilder HttpBuilder => new();
    }
}
