using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuanGua.PatentBus.Model
{
    public class JsonListEntity<T> : JsonEntity
    {
        /// <summary>
        /// 业务数据表
        /// </summary>
        public List<T> data { get; set; }
    }
}
