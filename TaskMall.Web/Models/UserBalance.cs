using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskMall.Web.Models
{
    public class UserBalance : Base
    {

        public int UserID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(Length = 255)]
        public string UserName { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        [SugarColumn(ColumnDataType = "decimal(18,4)")]
        public decimal Balance { get; set; }
    }
}