using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskMall.Web.Models
{
    public class Users : Base
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(Length = 255)]
        public string UserName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(Length = 255)]
        public string NickName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(Length = 255)]
        public string Password { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn()]
        public int Status { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        [SugarColumn(Length = 255, IsNullable = true)]
        public string UserImage { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [SugarColumn(Length = 25, IsNullable = true)]
        public string Mobile { get; set; }

        /// <summary>
        /// 支付宝账号（用作提现使用）
        /// </summary>
        [SugarColumn(Length = 255, IsNullable = true)]
        public string AliPay { get; set; }

        /// <summary>
        /// 完成任务数量
        /// </summary>
        public int SuccessTaskCount { get; set; }
        /// <summary>
        /// 锁定数量
        /// </summary>
        public int LockTaskCount { get; set; }
    }
}