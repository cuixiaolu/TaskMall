using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskMall.Web.Models
{
    public class UserAdmin : Base
    {
        /// <summary>
        /// 帐号
        /// </summary>
        [SugarColumn(Length = 255)]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(Length = 255)]
        public string Password { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        [SugarColumn(Length = 255)]
        public string Role { get; set; }
    }
}