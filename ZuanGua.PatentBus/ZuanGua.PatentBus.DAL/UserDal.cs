using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.DAL
{
    public class UserDal:BaseFactory<SYS_USER>
    {
        /// <summary>
        /// 根据我的邀请码获得用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public SYS_USER GetEntityByMyCode(string code)
        {
            return InitialBaseDal().LoadIQueryable<SYS_USER>(x => x.MyInviteCode == code).FirstOrDefault();
        }

        /// <summary>
        /// 根据邀请码获得用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public SYS_USER GetEntityByCode(string code)
        {
            return InitialBaseDal().LoadIQueryable<SYS_USER>(x => x.InviteCode == code).FirstOrDefault();
        }

        /// <summary>
        /// 根据邀请码获得用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public SYS_USER GetEntityByMobile(string mobile)
        {
            return InitialBaseDal().LoadIQueryable<SYS_USER>(x => x.MOBILE == mobile).FirstOrDefault();
        }

        /// <summary>
        /// 账户、密码是否正确
        /// </summary>
        /// <returns></returns>
        public SYS_USER GetEntityByMobilePWD(string mobile,string password)
        {
            return InitialBaseDal().LoadIQueryable<SYS_USER>(x => x.MOBILE == mobile && x.PASSWORD == password).FirstOrDefault();
        }
    }
}
