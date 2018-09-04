using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskMall.Web.Models
{
    public class Tasks : Base
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [SugarColumn(Length = 255)]
        public string Type { get; set; }
        /// <summary>
        /// 发布人ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 需要完成数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 已完成数量
        /// </summary>
        public int SuccesCount { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop { get; set; }
        /// <summary>
        /// 发布人姓名
        /// </summary>
        [SugarColumn(Length = 255)]
        public string UserName { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [SugarColumn(ColumnDataType = "decimal(18,4)")]
        public decimal Price { get; set; }
        /// <summary>
        /// 描述，步骤 
        /// </summary>
        [SugarColumn(ColumnDataType = "Nvarchar(max)")]
        public string Desceription { get; set; }
    }
}