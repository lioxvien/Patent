using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ZuanGua.PatentBus.BLL;
using ZuanGua.PatentBus.Model;

namespace ZuanGua.PatentBus.UI.Portal.Controllers.SendSMS
{
    public class SendSMSController : Controller
    {
        string AlertMobile = "13212125816";
        SMS_SendBLL BLL = new SMS_SendBLL();
        SMS_Send_logBLL logbll = new SMS_Send_logBLL();
        // GET: SendSMS
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加短信信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonSoloEntity<SMS_Send> AddUserInfo(SMS_Send Model)
        {
            JsonSoloEntity<SMS_Send> result = new JsonSoloEntity<SMS_Send>();
            if (BLL.InsertInfo(Model))
            {
                result.success = "true";
                result.data = Model;
            }
            try
            {
                SMSSendAction(Model.smsCode, Model.smsNote, Model.id.ToString());
            }
            catch (Exception e)
            {
                UpdateMonitor("出现轮询错误：" + e.Message);
                throw;
            }
            return result;
        }

        /// <summary>
        /// 删除求购信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonEntity DelSMSSend(string ID)
        {
            JsonEntity result = new JsonEntity();
            SMS_SendBLL ticket = new SMS_SendBLL();
            result.success = "false";
            if (ticket.DeleteInfo(ID))
            {
                result.success = "true";
            }

            return result;
        }

        private void SMSSendAction(string mobile, string content, string smsID)
        {
            string resp = PushToWeb("http://web.cr6868.com/asmx/smsservice.aspx", StrAppend(content, mobile), Encoding.UTF8);
            string result = resp.Split(',')[0];
            if (result != "0")
            {
                UpdateMonitor("提交失败，手机号：" + mobile + "  返回值：" + resp.Split(',')[1]);
                string AlertContent = "【创通票】系统检测到错误短信：" + content + " 出错号码：" + mobile + " 错误日志：" + resp.Split(',')[1];
                //给管理员用户发送短信提醒
                PushToWeb("http://web.cr6868.com/asmx/smsservice.aspx", StrAppend(AlertContent, AlertMobile), Encoding.UTF8);
            }
            else
            {
                UpdateMonitor("提交成功，手机号：" + mobile);
            }
            BussHandler(smsID, result);
        }
        private string PushToWeb(string weburl, string data, Encoding encode)
        {
            byte[] byteArray = encode.GetBytes(data);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(weburl));
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;
            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();

            //接收返回信息：
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader aspx = new StreamReader(response.GetResponseStream(), encode);
            return aspx.ReadToEnd();
        }
        private void BussHandler(string smsID, string result)
        {
            try
            {
                SMS_Send model = BLL.Identity(smsID);
                SMS_Send_log modellog = new SMS_Send_log();

                modellog.sender = model.sender;
                modellog.smsCode = model.smsCode;
                modellog.smsNote = model.smsNote;
                modellog.createTime = DateTime.Now;
                modellog.isSuccessful = Convert.ToBoolean(result);
                //记录保存
                logbll.InsertInfo(modellog);


                DelSMSSend(smsID);
            }
            catch { }
        }
        private string StrAppend(string content, string mobile)
        {
            string pwd = ConfigurationManager.AppSettings["SendMsgPwd"];
            StringBuilder sms = new StringBuilder();
            sms.AppendFormat("name={0}", "13212125816");//填账号的登录名    
            sms.AppendFormat("&pwd={0}", pwd);
            sms.AppendFormat("&content={0}", content);
            sms.AppendFormat("&mobile={0}", mobile);
            sms.AppendFormat("&sign={0}", "");
            sms.Append("&type=pt");

            return sms.ToString();
        }
        private void UpdateMonitor(string text)
        {
           
        }


    }
}