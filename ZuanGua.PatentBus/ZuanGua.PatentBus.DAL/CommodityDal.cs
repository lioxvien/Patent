﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuanGua.PatentBus.Common;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.DAL
{
    public class CommodityDal : BaseFactory<Commodity>
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
        /// <summary>
        /// 获取求购信息
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns></returns>
        public IQueryable<Commodity> GetCommodity(string UserID)
        {
            return this.InitialBaseDal().LoadIQueryable<Commodity>(x => x.CreateUser == UserID);
        }

        /// <summary>
        /// 待服务信息
        /// </summary>
        /// <param name="page">分页类</param>
        /// <returns></returns>
        public DataTable GetCommodityList(PageModels page)
        {
            var ht = JsonConvert.DeserializeObject<Hashtable>(page.condition);
            string where = " where 1=1";
            if (ht.Contains("UserId"))
            {
                where += " and CreateUser = '" + ht["UserId"].ToString() + "'";
            }

            string sql = @"select * from Commodity A " + where;

            return this.InitialBaseDal().LoadTable(sql, page);
        }

    }
}
