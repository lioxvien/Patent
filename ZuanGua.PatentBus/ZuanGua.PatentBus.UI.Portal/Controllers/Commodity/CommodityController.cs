using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ZuanGua.PatentBus.BLL;
using ZuanGua.PatentBus.Common;

namespace ZuanGua.PatentBus.UI.Portal.Controllers.Commodity
{
    public class CommodityController : Controller
    {
        CommodityBll ComBll = new CommodityBll();

        // GET: Commodity
        public ActionResult SellIndex()
        {
            return View();
        }

        public string GetMySellList()
        {
            var list = ComBll.GetAllInfo();

            return JsonConvert.SerializeObject(list.ToArray());
        }

        //添加信息
        public ActionResult AddInfo(Model.Commodity model)
        {
            var info = ComBll.GetInfobyNum(model.AuthorizationNumber);
            string res = "";
            if (info.Count() > 0) 
            {
                
                res = "1";        //不能重复发布同一授权号的商品
            }
            else
            {
                ComBll.InsertInfo(model);
                res = "2";       //添加成功
            }

            return Redirect("SellIndex?res=" + res);
        }

        public string DeleteInfo(string id)
        {
            if (ComBll.DeleteInfo(id))
            {
                return "0";     //删除成功
            }
            else
            {
                return "1";     //删除失败，请重试
            }
        }

        public void DeleteBatch(List<Model.Commodity> models)
        {
            ComBll.DeleteInfo(models);
        }
    }
}