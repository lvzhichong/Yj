using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Yj.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // 自定义错误处理
            filters.Add(new CustomerErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Admin", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            
            // 初始化 AutoMapper 配置
            Yj.Biz.ObjectAutoMapper.Instance.Configure();
        }
    }

    /// <summary>
    /// 自定义错误处理
    /// </summary>
    public class CustomerErrorAttribute : HandleErrorAttribute 
    {
        public override void OnException(ExceptionContext filterContext)
        {
            // 处理json请求出错的

            base.OnException(filterContext);
        }
    }
}