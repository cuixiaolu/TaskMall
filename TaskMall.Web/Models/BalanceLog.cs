using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskMall.Web.Models
{
    public class BalanceLog : Base
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 操作金额
        /// </summary>
        [SugarColumn(ColumnDataType = "decimal(18,4)")]
        public decimal Amount { get; set; }
        /// <summary>
        /// 完成后余额
        /// </summary>
        [SugarColumn(ColumnDataType = "decimal(18,4)")]
        public decimal Balance { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(Length = 2000, IsNullable = true)]
        public string Remark { get; set; }
    }
}