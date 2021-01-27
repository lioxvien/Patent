using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuanGua.PatentBus.Common;
using ZuanGua.PatentBus.Model;
using Newtonsoft.Json;
using System.Collections;

namespace ZuanGua.PatentBus.DAL
{
    public class BuyingDAL : BaseFactory<Buying>
    {
        /// <summary>
        /// 获取所有出售信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<Buying> GetAllInfo()
        {
            return InitialBaseDal().LoadIQueryable<Buying>();
        }

        /// <summary>
        /// 获取求购信息
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns></returns>
        public IQueryable<Buying> GetBuying(string UserID)
        {
            return this.InitialBaseDal().LoadIQueryable<Buying>(x => x.CreateUser == UserID);
        }

        /// <summary>
        /// 待服务信息
        /// </summary>
        /// <param name="page">分页类</param>
        /// <returns></returns>
        public DataTable GetBuyingList(PageModels page)
        {
            var ht = JsonConvert.DeserializeObject<Hashtable>(page.condition);
            string where = " where 1=1";
            if (ht.Contains("UserId"))
            {
                where += " and CreateUser = '" + ht["UserId"].ToString() + "'";
            }

            string sql = @"select * from Buying A " + where;

            return this.InitialBaseDal().LoadTable(sql, page);
        }

    }
}
