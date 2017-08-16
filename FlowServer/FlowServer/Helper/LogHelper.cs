using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Diagnostics;
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

        private static string GetStackInfo(Exception exception = null)
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(exception, true);
            System.Diagnostics.StackFrame[] sfs = st.GetFrames();
            int i = -1;
            string CallFun = "";
            foreach (StackFrame sf in sfs)
            {
                if (System.Diagnostics.StackFrame.OFFSET_UNKNOWN == sf.GetILOffset()) break;
                Type callType = sf.GetMethod().DeclaringType;
                if (callType == typeof(LogHelper)) { i = 0; continue; }
                if (i < 0) continue;
                CallFun += callType.FullName + ":" + sf.GetMethod().Name + "()\r\n";
                if (i++ > 5) break;
            }
            return CallFun;
        }

        /// <summary>
        /// info
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(object message, Exception exception = null)
        {
            GetLogHelper();
            if (exception == null)
                _log.Info(message + "\r\n" + GetStackInfo());
            else
                _log.Info(message, exception);
        }

        /// <summary>
        /// debug
        /// </summary>
        /// <param name="msg"></param>
        public static void Debug(object message, Exception exception = null)
        {
            GetLogHelper();
            if (exception == null)
                _log.Debug(message + "\r\n" + GetStackInfo());
            else
                _log.Debug(message, exception);
        }

        /// <summary>
        /// error
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(object message, Exception exception = null)
        {
            GetLogHelper();
            if (exception == null)
                _log.Error(message + "\r\n" + GetStackInfo());
            else
                _log.Error(message, exception);
        }

        /// <summary>
        /// warn
        /// </summary>
        /// <param name="msg"></param>
        public static void Warn(object message, Exception exception = null)
        {
            GetLogHelper();
            if (exception == null)
                _log.Warn(message + "\r\n" + GetStackInfo());
            else
                _log.Warn(message, exception);
        }
    }
}