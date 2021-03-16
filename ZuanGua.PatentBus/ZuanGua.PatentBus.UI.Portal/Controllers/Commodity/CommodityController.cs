using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ZuanGua.PatentBus.BLL;
using ZuanGua.PatentBus.Common;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.UI.Portal.Controllers.Commodity
{
    public class CommodityController : Controller
    {
        CommodityBll ComBll = new CommodityBll();

        // GET: Model.Commodity
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

        /// <summary>
        /// 添加求购信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddUserInfo(Model.Commodity Model)
        {
            JsonSoloEntity<Model.Commodity> result = new JsonSoloEntity<Model.Commodity>();
            Model.CommodityID = Guid.NewGuid().ToString();
            if (ComBll.InsertInfo(Model))
            {
                result.success = "true";
                result.data = Model;
            }
            return JsonConvert.SerializeObject(result);
        }
        /// <summary>
        /// 修改求购信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdUserInfo(Model.Commodity Model)
        {
            JsonSoloEntity<Model.Commodity> result = new JsonSoloEntity<Model.Commodity>();
            Model.Commodity item = ComBll.Identity(Model.CommodityID);
            if (item != null)
            {
                item.CommodityType = Model.CommodityType;
                item.CommodityField = Model.CommodityField;
                item.SalePrice = Model.SalePrice;
                item.LinkMobile = Model.LinkMobile;
                if (ComBll.UpdateInfo(item))
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

            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 审核信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public string CheckUserInfo(Model.Commodity Model)
        {
            JsonSoloEntity<Model.Commodity> result = new JsonSoloEntity<Model.Commodity>();
            Model.Commodity item = ComBll.Identity(Model.CommodityID);

            if (item != null)
            {
                item.CommodityState = Model.CommodityState;
                if (ComBll.UpdateInfo(item))
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
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetCommodityList(int PageSize, int pageIndex, string UserId)
        {
            JsonListEntity<Model.Commodity> result = new JsonListEntity<Model.Commodity>();

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

            List<Model.Commodity> list = new List<Model.Commodity>();

            page.orderrow = "CreatTime";
            page.ordertype = "desc";
            DataTable dtWaitService = ComBll.GetCommodityList(page);

            result.success = "true";
            result.data = list;
            result.count = page.total;
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetCommodityById(string ID)
        {
            JsonSoloEntity<Model.Commodity> result = new JsonSoloEntity<Model.Commodity>();
            CommodityBll bll = new CommodityBll();
            if (ID == "")
            {
                result.success = "false";
                result.count = 0;
                result.errorMsg = "求购编号不能为空！";
                return JsonConvert.SerializeObject(result);
            }
            Model.Commodity model = bll.Identity(ID);
            result.success = "true";
            result.data = model;
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 根据UserId获取列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [HttpGet]
        public string MyCommodityList(string UserID)
        {
            JsonListEntity<Model.Commodity> result = new JsonListEntity<Model.Commodity>();
            if (UserID == "")
            {
                result.success = "false";
                result.count = 0;
                result.errorMsg = "用户编号不能为空！";
                return JsonConvert.SerializeObject(result);
            }
            List<Model.Commodity> list = ComBll.GetCommodity(UserID).ToList();
            if (list.Count == 0)
            {
                result.success = "false";
                result.errorMsg = "暂无数据！";
                return JsonConvert.SerializeObject(result);
            }
            result.data = list;
            result.count = list.Count;
            result.success = "true";
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 删除求购信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        [HttpPost]
        public string DelCommodity(string ID)
        {
            JsonEntity result = new JsonEntity();
            CommodityBll ticket = new CommodityBll();
            result.success = "false";
            if (ticket.DeleteInfo(ID))
            {
                result.success = "true";
            }

            return JsonConvert.SerializeObject(result);
        }
    }
}