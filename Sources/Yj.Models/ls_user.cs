using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Yj.Models
{
    /// <summary>
    /// ls_user 页面模型
    /// </summary>
    public class ls_userModel : BaseObjectModel<ls_user> { }

    /// <summary>
    /// ls_user
    /// </summary>
    public class ls_user : BaseObject
    {
        /// <summary>
        /// user_id
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public int duty_id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [RegularExpression("^[a-zA-Z0-9_]{5,20}$", ErrorMessage = "5-20个字符，可使用字母、数字、下划线")]
        [Remote("IsExistUserName", "User", ErrorMessage = "用户名已存在", AdditionalFields = "user_id")]
        public string user_name { get; set; }
        /// <summary>
        /// 用户密码 明文
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [RegularExpression("^[@A-Za-z0-9!#$%^&*.~_-]{6,20}$", ErrorMessage = "6-20个字符，区分大小写")]
        [DataType(DataType.Password)]
        public string user_password { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        [System.Web.Mvc.Compare("user_password", ErrorMessage = "密码和确认密码不一致")]
        [DataType(DataType.Password)]
        public string user_confirm_password { get; set; }
        /// <summary>
        /// 旧密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.Password)]
        public string user_old_password { get; set; }
        /// <summary>
        /// nick_name
        /// </summary>
        public string nick_name { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [RegularExpression("^[A-Za-z0-9]+([-_.][A-Za-z0-9]+)*@([A-Za-z0-9]+[-.])+[A-Za-z0-9]{2,5}$", ErrorMessage = "邮箱格式不对")]
        [Remote("IsExistEmail", "User", ErrorMessage = "邮箱已存在", AdditionalFields = "user_id")]
        public string email { get; set; }
        /// <summary>
        /// 是否允许登录，默认 0
        /// </summary>
        public bool is_approved { get; set; }
        /// <summary>
        /// 是否锁定，默认 0
        /// </summary>
        public bool is_lock { get; set; }
        /// <summary>
        /// 锁定时间
        /// </summary>
        public DateTime? lock_date { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime modify_date { get; set; }
        /// <summary>
        /// last_login_date
        /// </summary>
        public DateTime last_login_date { get; set; }
        /// <summary>
        /// 是否已删除，默认 0
        /// </summary>
        public bool is_del { get; set; }
    }
}