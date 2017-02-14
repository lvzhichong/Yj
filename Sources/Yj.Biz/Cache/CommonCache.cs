using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yj.Biz.Cache
{
    /// <summary>
    /// 系统中使用的缓存数据，一般为数据量不大的，不必链表查询的单表数据
    /// </summary>
    public class CommonCache
    {
        private static List<Models.ls_duty> dutys = null;

        /// <summary>
        /// 角色数据 - 缓存
        /// </summary>
        public static List<Models.ls_duty> Dutys
        {
            get
            {
                if (dutys == null)
                {
                    // 从数据库获取
                    dutys = Biz.ls_dutyBiz.Instance.GetList().ToList();
                }

                return dutys;
            }
        }

        /// <summary>
        /// 获取角色名字
        /// </summary>
        /// <param name="duty_id"></param>
        /// <returns></returns>
        public static string GetDutyName(int duty_id)
        {
            Models.ls_duty duty = Dutys.Where(d => d.duty_id == duty_id).FirstOrDefault();

            if (duty != null)
            {
                return duty.duty_name;
            }

            return "";
        }

        private static List<Models.ls_role> roles = null;

        /// <summary>
        /// 权限数据 - 缓存
        /// </summary>
        public static List<Models.ls_role> Roles
        {
            get
            {
                if (roles == null)
                {
                    // 从数据库获取
                    roles = Biz.ls_roleBiz.Instance.GetList(null).ToList();
                }

                return roles;
            }
        }

        /// <summary>
        /// 模块分类数据
        /// </summary>
        public static Dictionary<string, string> ModuleCategories
        {
            get
            {
                Dictionary<string, string> categories = new Dictionary<string, string>();

                categories.Add("system", "系统管理");

                return categories;
            }
        }

        /// <summary>
        /// 获取模块分类名字
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetModuleCategory(string key)
        {
            if (!string.IsNullOrEmpty(key) && ModuleCategories.ContainsKey(key))
            {
                return ModuleCategories[key];
            }

            return "";
        }
    }
}
