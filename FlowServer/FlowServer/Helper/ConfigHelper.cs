using Newtonsoft.Json.Linq;
using System.IO;

namespace FlowServer.Helper
{
    public class ConfigHelper
    {
        /// <summary>
        /// 日志
        /// </summary>
        private static JObject _json;

        /// <summary>
        /// 锁
        /// </summary>
        private static readonly object _lock = new object();

        private ConfigHelper() { }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <returns></returns>
        public static JObject GetConfigHelper()
        {
            if (_json == null)
            {
                lock (_lock)
                {
                    if (_json == null)
                    {
                        string s = File.ReadAllText("Config/config.txt");
                        _json = JObject.Parse(s);
                    }
                }
            }
            return _json;
        }

        /// <summary>
        /// 根据键来获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            GetConfigHelper();
            return _json[key].ToString();
        }
    }
}