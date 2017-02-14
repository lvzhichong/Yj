using System;
// log4net
using log4net;

namespace Yj.Common
{
    /// <summary>
    /// 日志管理类
    /// 初始化框架日志管理，自定义日志管理，如果有需要，可以重写下面方法
    /// </summary>
    public class Logger
    {
        // 日志记录对象
        private static ILog _logger = LogManager.GetLogger(string.Empty);

        /// <summary>
        /// Debug 日志记录
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="moduleType"></param>
        public static void Debug(string message)
        {
            _logger.Debug(message);
        }

        /// <summary>
        /// Debug 日志记录
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="moduleType"></param>
        public static void Debug(string message, Exception ex)
        {
            _logger.Debug(message, ex);
        }

        /// <summary>
        /// Error 异常日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="moduleType"></param>
        public static void Error(string message)
        {
            _logger.Error(message);
        }

        /// <summary>
        /// Error 异常日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="moduleType"></param>
        public static void Error(string message, Exception ex)
        {
            _logger.Error(message, ex);
        }

        /// <summary>
        /// Fatal 错误日志记录
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="moduleType"></param>
        public static void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        /// <summary>
        /// Fatal 错误日志记录
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="moduleType"></param>
        public static void Fatal(string message, Exception ex)
        {
            _logger.Fatal(message, ex);
        }

        /// <summary>
        /// 普通信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="moduleType"></param>
        public static void Info(string message)
        {
            _logger.Info(message);
        }

        /// <summary>
        /// 普通信息
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="moduleType"></param>
        public static void Info(string message, Exception ex)
        {
            _logger.Info(message, ex);
        }

        /// <summary>
        /// Warn 错误日志记录
        /// </summary>
        /// <param name="message"></param>
        /// <param name="moduleType"></param>
        public static void Warn(string message)
        {
            _logger.Warn(message);
        }

        /// <summary>
        /// Warn 错误日志记录
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="moduleType"></param>
        public static void Warn(string message, Exception ex)
        {
            _logger.Warn(message, ex);
        }
    }
}
