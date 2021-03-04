using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuanGua.PatentBus.DAL;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.BLL
{
    public class SMS_SendBLL
    {
        SMS_SendDAL dal = new SMS_SendDAL();
        /// <summary>
        /// 添加短信
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertInfo(SMS_Send model)
        {
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
        /// 根据id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SMS_Send Identity(string id)
        {
            return dal.LoadEntity(id);
        }
    }
}
