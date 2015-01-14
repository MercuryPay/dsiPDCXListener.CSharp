using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace dsiPDCXListener.Infrastructure
{
    public class ConfigHelper
    {
        public string MerchantName
        {
            get { return ConfigurationManager.AppSettings["MerchantName"]; }
        }

        public string MerchantID
        {
            get { return ConfigurationManager.AppSettings["MerchantID"]; }
        }

        public string MerchantAddress
        {
            get { return ConfigurationManager.AppSettings["MerchantAddress"]; }
        }

        public string MerchantCity
        {
            get { return ConfigurationManager.AppSettings["MerchantCity"]; }
        }

        public string MerchantState
        {
            get { return ConfigurationManager.AppSettings["MerchantState"]; }
        }

        public string MerchantPostalCode
        {
            get { return ConfigurationManager.AppSettings["MerchantPostalCode"]; }
        }

        public string TranDeviceID
        {
            get { return ConfigurationManager.AppSettings["TranDeviceID"]; }
        }

        public string PostURL
        {
            get { return ConfigurationManager.AppSettings["PostURL"]; }
        }

        public string PostURLMethod
        {
            get { return ConfigurationManager.AppSettings["PostURLMethod"]; }
        }

        public string PrintReceiptMessageMethod4
        {
            get { return "TranDeviceID={0}&TranCode=PrintReceipt&OperatorID=danotest&MerchantID=NONE&ComPort=0&TStream=Admin&SecureDevice=NONE{1}"; }
        }

        public string PrintPoleDisplayMessageMethod4
        {
            get {return "TranDeviceID={0}&TranCode=PoleDisplay&OperatorID=danotest&MerchantID=NONE&ComPort=0&TStream=Admin&SecureDevice=NONE{1}";}
        }

        public string CashDrawerMessageMethod4
        {
            get {return "TranDeviceID={0}&TranCode=DrawerOpen&OperatorID=danotest&MerchantID=494901&ComPort=0&TStream=Admin&SecureDevice=ONTRAN";}
        }

        public string SaleMessageMethod4
        {
            get { return "TranDeviceID={0}&TranType={1}&TranCode=Sale&OperatorID=danotest&MerchantID=494901&ComPort=0&TStream=Transaction&SecureDevice=ONTRAN&InvoiceNo=123&RefNo=123&AcctNo=SecureDevice&Purchase={2}"; }
        }

        public string PrintReceiptMessageMethod1
        {
            get { return "<?xml version=\"1.0\"?><TStream><Admin><TranDeviceID>{0}</TranDeviceID><TranCode>PrintReceipt</TranCode><MerchantID>494901</MerchantID><ComPort>0</ComPort><SecureDevice>ONTRAN</SecureDevice>{1}</Admin></TStream>"; }            
        }

        public string PrintPoleDisplayMessageMethod1
        {
            get { return "<?xml version=\"1.0\"?><TStream><Admin><TranDeviceID>{0}</TranDeviceID><TranCode>PoleDisplay</TranCode><MerchantID>494901</MerchantID><ComPort>0</ComPort><SecureDevice>ONTRAN</SecureDevice>{1}</Admin></TStream>"; }
        }

        public string CashDrawerMessageMethod1
        {
            get { return "<?xml version=\"1.0\"?><TStream><Admin><TranDeviceID>{0}</TranDeviceID><TranCode>DrawerOpen</TranCode><MerchantID>494901</MerchantID><ComPort>0</ComPort><SecureDevice>ONTRAN</SecureDevice></Admin></TStream>"; }
        }

        public string SaleMessageMethod1
        {
            get { return "<?xml version=\"1.0\"?><TStream><Transaction><TranDeviceID>{0}</TranDeviceID><TranType>{1}</TranType><OperatorID>danotest</OperatorID><TranCode>Sale</TranCode><InvoiceNo>123</InvoiceNo><RefNo>123</RefNo><AcctNo>SecureDevice</AcctNo><Purchase>{2}</Purchase><MerchantID>494901</MerchantID><ComPort>0</ComPort><SecureDevice>ONTRAN</SecureDevice></Transaction></TStream>"; }
        }

        public string ContentTypeMethod1
        {
            get { return "text/plain"; }
        }

        public string ContentTypeMethod4
        {
            get { return "application/x-www-form-urlencoded"; }
        }
    }
}