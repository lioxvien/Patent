using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.DAL
{
    public class CommodityDal:BaseFactory<Commodity>
    {
        /// <summary>
        /// 获取所有出售信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<Commodity> GetAllInfo()
        {
            return InitialBaseDal().LoadIQueryable<Commodity>();
        }

        /// <summary>
        /// 根据授权号获取信息
        /// </summary>
        /// <param name="AuthorizationNumber"></param>
        /// <returns></returns>
        public IQueryable<Commodity> GetInfobyNum(string AuthorizationNumber)
        {
            return InitialBaseDal().LoadIQueryable<Commodity>(x => x.AuthorizationNumber == AuthorizationNumber);
        }
    }
}
