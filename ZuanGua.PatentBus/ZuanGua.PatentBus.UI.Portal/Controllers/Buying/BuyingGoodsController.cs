using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZuanGua.PatentBus.BLL;
using ZuanGua.PatentBus.Common;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.UI.Portal.Controllers.BuyingGoods
{
    public class BuyingGoodsController : Controller
    {
        BuyingBLL BLL = new BuyingBLL();
        // GET: BuyingGoods
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加求购信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonSoloEntity<Buying> AddUserInfo(Buying Model)
        {
            JsonSoloEntity<Buying> result = new JsonSoloEntity<Buying>();
            Model.CommodityID = Guid.NewGuid().ToString();
            if (BLL.InsertInfo(Model))
            {
                result.success = "true";
                result.data = Model;
            }
            return result;
        }
        /// <summary>
        /// 修改求购信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonSoloEntity<Buying> UpdUserInfo(Buying Model)
        {
            JsonSoloEntity<Buying> result = new JsonSoloEntity<Buying>();
            Buying item = BLL.Identity(Model.CommodityID);
            if (item != null)
            {
                item.CommodityType = Model.CommodityType;
                item.CommodityField = Model.CommodityField;
                item.SalePrice = Model.SalePrice;
                item.LinkMobile = Model.LinkMobile;
                if (BLL.UpdateInfo(item))
                {
                    result.success = "true";
                    result.data = item;
                }
                else
                {
                    result.success = "false";
                    result.errorMsg = "修改失败";
                }
            }
            else
            {
                result.success = "false";
                result.errorMsg = "未找到该专利信息";
            }

            return result;
        }

        /// <summary>
        /// 审核求购信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonSoloEntity<Buying> CheckUserInfo(Buying Model)
        {
            JsonSoloEntity<Buying> result = new JsonSoloEntity<Buying>();
            Buying item = BLL.Identity(Model.CommodityID);

            if (item != null)
            {
                item.CommodityState = Model.CommodityState;
                if (BLL.UpdateInfo(item))
                {
                    result.success = "true";
                    result.data = item;
                }
                else
                {
                    result.success = "false";
                    result.errorMsg = "审核失败";
                }
            }
            else
            {
                result.success = "false";
                result.errorMsg = "未找到该专利信息";
            }
            return result;
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonListEntity<Buying> GetBuyingList(int PageSize, int pageIndex, string UserId)
        {
            JsonListEntity<Buying> result = new JsonListEntity<Buying>();

            //if (UserId == "")
            //{
            //    result.success = "false";
            //    result.count = 0;
            //    result.errorMsg = "用户编号无效！";
            //    return result;
            //}

            Hashtable ht = new Hashtable();
            if (UserId != null && UserId != "")
            {
                ht.Add("UserId", UserId);
            }

            PageModels page = new PageModels();
            page.pageSize = PageSize;
            page.pageIndex = pageIndex;
            page.total = 0;
            page.condition = JsonConvert.SerializeObject(ht);

            List<Buying> list = new List<Buying>();

            page.orderrow = "CreatTime";
            page.ordertype = "desc";
            DataTable dtWaitService = BLL.GetBuyingList(page);

            result.success = "true";
            result.data = list;
            result.count = page.total;
            return result;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonSoloEntity<Buying> GetBuyingById(string ID)
        {
            JsonSoloEntity<Buying> result = new JsonSoloEntity<Buying>();
            BuyingBLL bll = new BuyingBLL();
            if (ID == "")
            {
                result.success = "false";
                result.count = 0;
                result.errorMsg = "求购编号不能为空！";
                return result;
            }
            Buying model = bll.Identity(ID);
            result.success = "true";
            result.data = model;
            return result;
        }

        /// <summary>
        /// 根据UserId获取列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonListEntity<Buying> MyBuyingList(string UserID)
        {
            JsonListEntity<Buying> result = new JsonListEntity<Buying>();
            if (UserID == "")
            {
                result.success = "false";
                result.count = 0;
                result.errorMsg = "用户编号不能为空！";
                return result;
            }
            List<Buying> list = BLL.GetBuying(UserID).ToList();
            if (list.Count == 0)
            {
                result.success = "false";
                result.errorMsg = "暂无数据！";
                return result;
            }
            result.data = list;
            result.count = list.Count;
            result.success = "true";
            return result;
        }

        /// <summary>
        /// 删除求购信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonEntity DelBuying(string ID)
        {
            JsonEntity result = new JsonEntity();
            BuyingBLL ticket = new BuyingBLL();
            result.success = "false";
            if (ticket.DeleteInfo(ID))
            {
                result.success = "true";
            }

            return result;
        }


    }
}