using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.DAL
{
    public class DbContextFactory
    {
        /// <summary>
        /// 负责创建EF数据操作上下文实例,必须保证线程内唯一
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateContext()
        {
            return new DataModel();
        }
    }
}
