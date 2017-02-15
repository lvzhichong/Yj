using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yj.Web.Controllers
{
    [Authorize]
    public class BaseAuthorizeController : Controller
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public Yj.Models.ls_user current_user
        {
            get
            {
                return Biz.ls_userBiz.Instance.GetModelByName(HttpContext.User.Identity.Name);
            }
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <returns></returns>
        public void add_log(string description)
        {
            try
            {
                Yj.Models.ls_log log = new Yj.Models.ls_log
                {
                    user_id = current_user.user_id,
                    user_name = current_user.user_name,
                    log_description = description,
                    log_date = DateTime.Now
                };

                Biz.ls_logBiz.Instance.AddLog(log);
            }
            catch (Exception ex)
            {
                Common.Logger.Error("添加日志出错，日志信息：" + description, ex);
            }
        }
    }
}
