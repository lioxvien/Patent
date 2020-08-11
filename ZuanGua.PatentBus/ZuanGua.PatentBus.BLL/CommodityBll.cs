using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuanGua.PatentBus.DAL;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.BLL
{
    public class CommodityBll
    {
        CommodityDal dal = new CommodityDal();

        /// <summary>
        /// 获取所有出售信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<Commodity> GetAllInfo()
        {
            return dal.GetAllInfo();
        }

        /// <summary>
        /// 根据授权号获取信息
        /// </summary>
        /// <param name="AuthorizationNumber"></param>
        /// <returns></returns>
        public IQueryable<Commodity> GetInfobyNum(string AuthorizationNumber)
        {
            return dal.GetInfobyNum(AuthorizationNumber);
        }

        /// <summary>
        /// 根据id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Commodity Identity(string id)
        {
            return dal.LoadEntity(id);
        }

        /// <summary>
        /// 添加出售专利
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertInfo(Commodity model)
        {
            model.CommodityID = Guid.NewGuid().ToString();
            model.ComplaintCount = 0;
            model.CreateTime = DateTime.Now;

            return Convert.ToBoolean(dal.Insert(model));
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteInfo(string id)
        {
            var info = Identity(id);
            return Convert.ToBoolean(dal.Delete(info));
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteInfo(List<Commodity> models)
        {
            foreach (var item in models)
            {
                dal.Delete(item);
            }
        }
    }
}
