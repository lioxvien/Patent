using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuanGua.PatentBus.Common;
using ZuanGua.PatentBus.DAL;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.BLL
{
    public class UserBLL
    {
        UserDal dal = new UserDal();

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(SYS_USER model)
        {
            model.USERID = Guid.NewGuid().ToString();
            model.CREATETIME = DateTime.Now;
            model.Point = 0;
            model.PASSWORD = Encrypt.MD5EncryptStr(model.PASSWORD);

            return Convert.ToBoolean(dal.Insert(model));
        }

        /// <summary>
        /// 根据主键获取信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public SYS_USER Identity(string userid)
        {
            return dal.LoadEntity(userid);
        }

        /// <summary>
        /// 根据主键获取信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public UserBaseInfo IdentityUserBase(string userid)
        {
            var model = dal.LoadEntity(userid);

            UserBaseInfo info = new UserBaseInfo();
            info.USERID = model.USERID;
            info.MOBILE = model.MOBILE;
            info.UserRole = model.UserRole;
            info.InviteCode = model.InviteCode;
            info.MyInviteCode = model.MyInviteCode;
            info.Point = model.Point;
            info.USERID = model.USERID;

            return info;
        }

        /// <summary>
        /// 根据我的邀请码获得用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public SYS_USER GetEntityByMyCode(string code)
        {
            return dal.GetEntityByMyCode(code);
        }

        /// <summary>
        /// 根据邀请码获得用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public SYS_USER GetEntityByCode(string code)
        {
            return dal.GetEntityByCode(code);
        }

        /// <summary>
        /// 根据手机号获得用户信息
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public SYS_USER GetEntityByMobile(string mobile)
        {
            return dal.GetEntityByMobile(mobile);
        }

        /// <summary>
        /// 账户、密码是否正确
        /// </summary>
        /// <returns></returns>
        public SYS_USER GetEntityByMobilePWD(string mobile, string password)
        {
            string PASSWORD = Encrypt.MD5EncryptStr(password);
            return dal.GetEntityByMobilePWD(mobile, PASSWORD);
        }

        /// <summary>
        /// 生成我的邀请码
        /// </summary>
        /// <returns></returns>
        public string GetMyInviteCode()
        {
            var code = CreateData.getInviteCode();
            var model = dal.GetEntityByCode(code);
            if (model != null)
            {
                return GetMyInviteCode();
            }
            else
            {
                return code;
            }
        }
    }
}
