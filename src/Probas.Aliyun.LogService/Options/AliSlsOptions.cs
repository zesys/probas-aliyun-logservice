namespace Probas.Aliyun.LogService
{
    public class AliSlsOptions
    {
        /// <summary>
        /// 日志服务的域名，更多域名信息，请参见服务入口。
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// 阿里云访问密钥AccessKey ID。更多信息，请参见访问密钥。阿里云主账号AccessKey拥有所有API的访问权限，风险很高。强烈建议您创建并使用RAM账号进行API访问或日常运维。
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// 阿里云访问密钥AccessKey Secret。更多信息，请参见访问密钥。阿里云主账号AccessKey拥有所有API的访问权限，风险很高。强烈建议您创建并使用RAM账号进行API访问或日常运维。
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 已创建的日志服务Project名称。
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// 已创建的日志服务Logstore名称。
        /// </summary>
        public string Logstore { get; set; }
    }
}
