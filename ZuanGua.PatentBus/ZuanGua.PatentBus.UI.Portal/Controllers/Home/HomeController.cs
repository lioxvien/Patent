using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZuanGua.PatentBus.BLL;
using ZuanGua.PatentBus.Common;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.UI.Portal.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //登录页
        public ActionResult Login()
        {
            return View();
        }

        //注册页
        public ActionResult Register()
        {
            return View();
        }

        //添加注册信息
        [HttpPost]
        public string RegisterInfo(RegisterModel model)
        {
            UserBLL bll = new UserBLL();

            SYS_USER user = new SYS_USER();
            user.USERNAME = model.USERNAME;
            user.MOBILE = model.MOBILE;
            user.PASSWORD = model.PASSWORD; 
            user.InviteCode = model.InviteCode;
            user.MyInviteCode = bll.GetMyInviteCode();

            #region 验证手机号
            try
            {
                var mData = bll.GetEntityByMobile(model.MOBILE);
                if (mData != null)
                {
                    return "4";//手机号已注册，请直接登录
                }
            }
            catch (Exception)
            {
                return "4";
                throw;
            }
            #endregion

            #region 验证验证码
            try
            {
                if (model.YZM != Session["ValidateCode"].ToString())
                {
                    return "2";//验证码错误
                }
            }
            catch (Exception)
            {
                return "2";
                throw;
            }
            #endregion

            #region 验证邀请码
            try
            {
                if (model.InviteCode != "shqnadmin")
                {
                    var data = bll.GetEntityByMyCode(model.InviteCode);
                    if (data == null)
                    {
                        return "3";//邀请码不存在
                    }
                }
            }
            catch (Exception)
            {
                return "3";
                throw;
            }
            #endregion

            if (bll.Insert(user))
            {
                return "0";//注册成功
            }
            else
            {
                return "1";//注册失败
            }
        }

        //登录
        [HttpPost]
        public string Login(RegisterModel model)
        {
            UserBLL bll = new UserBLL();
            
            // 验证手机号/密码
            var mData = bll.GetEntityByMobile(model.MOBILE);
            if (mData == null)
            {
                return "4";//手机号未注册，请注册后登录
            }
            else
            {
                bool res = Encrypt.MD5DecryptStr(model.PASSWORD, mData.PASSWORD);
                if (!res)
                {
                    return "3";//手机号或密码不正确
                }
            }

            // 验证验证码
            if (model.YZM != Session["ValidateCode"].ToString())
            {
                return "2";//验证码错误
            }

            UserBaseInfo uper = bll.IdentityUserBase(mData.USERID);
            Session["UserData"] = uper;

            if (SessionHelper.IsUserLogin) 
            {
                return "0";//登录成功
            }
            else
            {
                return "1";//登录失败
            }
        }

        //验证码
        public ActionResult IdentifyCode()
        {
            Session.Remove("ValidateCode");
            Response.Buffer = true;

            string strKey = "";
            Random rd = new Random();
            int CodeLen = new Random().Next(4, 5);//产生4位或5位验证码
            byte[] data = CreateData.GetVerifyImage(CodeLen, ref strKey);

            Session["ValidateCode"] = strKey;
            Response.ClearContent();
            Response.OutputStream.Write(data, 0, data.Length);

            return View();
        }
    }
}