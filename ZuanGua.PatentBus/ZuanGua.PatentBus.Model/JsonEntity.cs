using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuanGua.PatentBus.Model
{
    public class JsonEntity
    {
        /// <summary>
        /// 成功标记
        /// </summary>
        public string success { get; set; }

        /// <summary>
        /// 数据数量
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string errorMsg { get; set; }
    }
}
