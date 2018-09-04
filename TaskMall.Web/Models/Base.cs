using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskMall.Web.Models
{
    public class Base
    {
        /// <summary>
        ///ID
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Created { get; set; }
    }
}