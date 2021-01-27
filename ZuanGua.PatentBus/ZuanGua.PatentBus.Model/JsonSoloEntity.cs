using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuanGua.PatentBus.Model
{
    public class JsonSoloEntity<T> : JsonEntity
    {
        /// <summary>
        /// 单个业务数据
        /// </summary>
        public T data { get; set; }
    }
}
