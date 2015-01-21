using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dsiPDCXListener.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Admin(dsiPDCXListener.Models.AdminData adminData)
        {
            if (adminData != null && (adminData.ComPort != null || adminData.PostURL != null || adminData.PostURLMethod != null || adminData.SecureDevice != null && adminData.TranDeviceID != null || adminData.MerchantID != null))
            {
                HttpContext.Application["TranDeviceID"] = (adminData.TranDeviceID == null) ? "" : adminData.TranDeviceID;
                HttpContext.Application["PostURL"] = adminData.PostURL;
                HttpContext.Application["PostURLMethod"] = adminData.PostURLMethod;
                HttpContext.Application["ComPort"] = adminData.ComPort;
                HttpContext.Application["SecureDevice"] = adminData.SecureDevice;
                HttpContext.Application["MerchantID"] = adminData.MerchantID;
                HttpContext.Application["IncludeRecordNoAndFrequency"] = adminData.IncludeRecordNoAndFrequency;

                return Redirect("/");
            }
            else
            {
                var theAdminData = new dsiPDCXListener.Models.AdminData();
                theAdminData.PostURL = HttpContext.Application["PostURL"].ToString();
                theAdminData.TranDeviceID = HttpContext.Application["TranDeviceID"].ToString();
                theAdminData.PostURLMethod = HttpContext.Application["PostURLMethod"].ToString();
                theAdminData.ComPort = HttpContext.Application["ComPort"].ToString();
                theAdminData.SecureDevice = HttpContext.Application["SecureDevice"].ToString();
                theAdminData.MerchantID = HttpContext.Application["MerchantID"].ToString();
                theAdminData.IncludeRecordNoAndFrequency = (bool)(HttpContext.Application["IncludeRecordNoAndFrequency"]);

                return View(theAdminData);
            }
        }

        public ActionResult Pizza()
        {
            ViewBag.Message = "Pizza";

            var config = new dsiPDCXListener.Infrastructure.ConfigHelper();

            var configData = new dsiPDCXListener.Models.ConfigurationData();
            configData.MerchantAddress = config.MerchantAddress;
            configData.MerchantCity = config.MerchantCity;            
            configData.MerchantName = config.MerchantName;
            configData.MerchantPostalCode = config.MerchantPostalCode;
            configData.MerchantState = config.MerchantState;
            configData.PostURL = HttpContext.Application["PostURL"].ToString();
            configData.PostURLMethod = HttpContext.Application["PostURLMethod"].ToString();
            configData.ComPort = HttpContext.Application["ComPort"].ToString();
            configData.SecureDevice = HttpContext.Application["SecureDevice"].ToString();
            configData.MerchantID = HttpContext.Application["MerchantID"].ToString();         

            if (configData.PostURLMethod == "method1")
            {
                configData.PrintReceiptMessage = config.PrintReceiptMessageMethod1;
                configData.PrintPoleDisplayMessage = config.PrintPoleDisplayMessageMethod1;
                configData.CashDrawerMessage = config.CashDrawerMessageMethod1;
                configData.SaleMessage = config.SaleMessageMethod1;
                configData.ContentType = config.ContentTypeMethod1;

                configData.TranDeviceID = (HttpContext.Application["TranDeviceID"].ToString().Length == 0) ? string.Empty : "<TranDeviceID>" + HttpContext.Application["TranDeviceID"].ToString() + "</TranDeviceID>";

                if ((bool)(HttpContext.Application["IncludeRecordNoAndFrequency"]))
                {
                    configData.IncludeRecordNoAndFrequency = config.RecordNoFrequencyMethod1;
                }
                else
                {
                    configData.IncludeRecordNoAndFrequency = string.Empty;
                }
            }
            else
            {
                configData.PrintReceiptMessage = config.PrintReceiptMessageMethod4;
                configData.PrintPoleDisplayMessage = config.PrintPoleDisplayMessageMethod4;
                configData.CashDrawerMessage = config.CashDrawerMessageMethod4;
                configData.SaleMessage = config.SaleMessageMethod4;
                configData.ContentType = config.ContentTypeMethod4;

                configData.TranDeviceID = (HttpContext.Application["TranDeviceID"].ToString().Length == 0) ? string.Empty : "TranDeviceID=" + HttpContext.Application["TranDeviceID"].ToString() + "&";

                if ((bool)(HttpContext.Application["IncludeRecordNoAndFrequency"]))
                {
                    configData.IncludeRecordNoAndFrequency = config.RecordNoFrequencyMethod4;
                }
                else
                {
                    configData.IncludeRecordNoAndFrequency = string.Empty;
                }
            }
 
            return View(configData);
        }

        public ActionResult PurchaseResults(string mydata)
        {
            var nvc = HttpUtility.ParseQueryString(mydata);
            var paymentResponseContaner = new dsiPDCXListener.Models.PaymentResponseContainer();

            var config = new dsiPDCXListener.Infrastructure.ConfigHelper();

            var configData = new dsiPDCXListener.Models.ConfigurationData();
            configData.MerchantAddress = config.MerchantAddress;
            configData.MerchantCity = config.MerchantCity;
            configData.MerchantName = config.MerchantName;
            configData.MerchantPostalCode = config.MerchantPostalCode;
            configData.MerchantState = config.MerchantState;
            configData.PostURL = HttpContext.Application["PostURL"].ToString();
            configData.TranDeviceID = HttpContext.Application["TranDeviceID"].ToString();
            configData.ComPort = HttpContext.Application["ComPort"].ToString();
            configData.SecureDevice = HttpContext.Application["SecureDevice"].ToString();
            configData.MerchantID = HttpContext.Application["MerchantID"].ToString();


            var paymentResponseData = new dsiPDCXListener.Models.PaymentResponseData();
            paymentResponseData.AcctNo = nvc["AcctNo"];
            paymentResponseData.AuthCode = nvc["AuthCode"];
            paymentResponseData.Authorize = nvc["Authorize"];
            paymentResponseData.CaptureStatus = nvc["CaptureStatus"];
            paymentResponseData.CardType = nvc["CardType"];
            paymentResponseData.CmdStatus = nvc["CmdStatus"];
            paymentResponseData.DSIXReturnCode = nvc["DSIXReturnCode"];
            paymentResponseData.InvoiceNo = nvc["InvoiceNo"];
            paymentResponseData.MerchantID = nvc["MerchantID"];
            paymentResponseData.Purchase = nvc["Purchase"];
            paymentResponseData.RecordNo = nvc["RecordNo"];
            paymentResponseData.RefNo = nvc["RefNo"];
            paymentResponseData.ResponseOrigin = nvc["ResponseOrigin"];
            paymentResponseData.TextResponse = nvc["TextResponse"];
            paymentResponseData.TranCode = nvc["TranCode"];

            paymentResponseContaner.PaymentResponseData = paymentResponseData;
            paymentResponseContaner.ConfigurationData = configData;

            ViewBag.Message = paymentResponseData.CmdStatus;

            return View(paymentResponseContaner);
        }
    }
}