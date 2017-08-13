using log4net;
using log4net.Config;
using log4net.Repository;
using System.IO;

namespace FlowServer.Helper
{
    public class LogHelper
    {
        /// <summary>
        /// 日志
        /// </summary>
        private static ILog _log;

        /// <summary>
        /// 锁
        /// </summary>
        private static readonly object _lock = new object();

        private LogHelper() { }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <returns></returns>
        public static ILog GetLogHelper()
        {
            if (_log == null)
            {
                lock (_lock)
                {
                    if (_log == null)
                    {
                        ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
                        XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
                        _log = LogManager.GetLogger(repository.Name, "NETCorelog4net");
                    }
                }
            }
            return _log;
        }

        /// <summary>
        /// info
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(string msg)
        {
            GetLogHelper();
            _log.Info(msg);
        }

        /// <summary>
        /// debug
        /// </summary>
        /// <param name="msg"></param>
        public static void Debug(string msg)
        {
            GetLogHelper();
            _log.Debug(msg);
        }

        /// <summary>
        /// error
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg)
        {
            GetLogHelper();
            _log.Error(msg);
        }

        /// <summary>
        /// warn
        /// </summary>
        /// <param name="msg"></param>
        public static void Warn(string msg)
        {
            GetLogHelper();
            _log.Warn(msg);
        }
    }
}