using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
//
using System.Reflection;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace Yj.Common
{
    public class Config
    {
        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        private static Configuration LoadConfiguration()
        {
            if (HttpContext.Current == null)
            {
                Configuration conf = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
                return conf;
            }
            else
            {
                Configuration conf = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                return conf;
            }
        }

        /// <summary>
        /// 获取 config 中配置的字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                Configuration conf = LoadConfiguration();

                if (conf != null)
                {
                    var str = conf.AppSettings.Settings[key];

                    if (str != null)
                    {
                        return str.Value;
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// 获取 config 中配置的 bool 值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool? GetConfigBool(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                Configuration conf = LoadConfiguration();

                if (conf != null)
                {
                    var str = conf.AppSettings.Settings[key];

                    bool boolValue = false;

                    if (str != null && !string.IsNullOrEmpty(str.Value) && bool.TryParse(str.Value, out boolValue))
                    {
                        return boolValue;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 获取 config 中配置的 int 值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int? GetConfigInt(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                Configuration conf = LoadConfiguration();

                if (conf != null)
                {
                    var str = conf.AppSettings.Settings[key];

                    int intValue;

                    if (str != null && !string.IsNullOrEmpty(str.Value) && int.TryParse(str.Value, out intValue))
                    {
                        return intValue;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 网站名称
        /// </summary>
        public static string WebTitle
        {
            get
            {
                return GetConfigString("WebTitle");
            }
        }

        /// <summary>
        /// 每页多少条
        /// </summary>
        public static int PageSize
        {
            get
            {
                int? pageSize = GetConfigInt("PageSize");

                if (pageSize != null)
                {
                    return pageSize.Value;
                }

                return 10;
            }
        }
    }
}
