using Newtonsoft.Json.Linq;
using System.IO;

namespace FlowServer.Helper
{
    /// <summary>
    /// 配置工具类
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 工具
        /// </summary>
        private static ConfigHelper helper;
        private static JObject json;

        /// <summary>
        /// 锁
        /// </summary>
        private static readonly object _lock = new object();

        private ConfigHelper()
        {
            string s = File.ReadAllText("Config/config.txt");
            json = JObject.Parse(s);
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <returns></returns>
        public static ConfigHelper GetInstance()
        {
            if (helper == null)
            {
                lock (_lock)
                {
                    if (helper == null)
                    {

                        helper = new ConfigHelper();
                    }
                }
            }
            return helper;
        }

        /// <summary>
        /// 根据键来获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return json[key].ToString();
        }
    }
}