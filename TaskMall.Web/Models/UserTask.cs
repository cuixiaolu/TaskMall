using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskMall.Web.Models
{
    public class UserTask
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 任务ID
        /// </summary>
        public int TaskID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [SugarColumn(Length = 255)]
        public string TaskTitle { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [SugarColumn(ColumnDataType = "decimal(18,4)")]
        public decimal Price { get; set; }
    }
}