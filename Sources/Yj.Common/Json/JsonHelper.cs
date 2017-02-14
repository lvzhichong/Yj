using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using Newtonsoft.Json;

namespace Yj.Common
{
    /// <summary>
    /// Json操作类
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// 序列化对象为Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                Common.Logger.Error("Json序列化对象出错，ERROR：", ex);
            }

            return null;
        }

        /// <summary>
        /// 反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
            where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Common.Logger.Error("Json序列化对象出错，ERROR：", ex);
            }

            return null;
        }
    }

    /// <summary>
    /// Json数据
    /// </summary>
    public class JsonData<T> where T : class
    {
        /// <summary>
        /// 结果，成功与否
        /// </summary>
        public bool Flag { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> Data { get; set; }
    }
}
