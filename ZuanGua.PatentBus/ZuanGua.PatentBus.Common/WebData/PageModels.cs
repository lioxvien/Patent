using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuanGua.PatentBus.Common
{
    public class PageModels
    {
        /// <summary>
        /// 每页行数
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 排序列
        /// </summary>
        public string orderrow { get; set; }
        /// <summary>
        /// 排序类型
        /// </summary>
        public string ordertype { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string condition { get; set; }
    }
}
