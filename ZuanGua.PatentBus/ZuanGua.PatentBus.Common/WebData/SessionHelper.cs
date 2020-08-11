using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.Common
{
    public class SessionHelper
    {
        public static bool IsUserLogin { get { return (HttpContext.Current.Session["UserData"]) != null; } }

        public static UserBaseInfo Identity
        {
            get
            {
                var sen = (HttpContext.Current.Session["UserData"]);
                if (sen != null && sen is UserBaseInfo)
                {
                    return (sen as UserBaseInfo);
                }
                return null;
            }
        }
    }
}
