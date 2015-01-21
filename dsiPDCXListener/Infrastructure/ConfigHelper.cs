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


        public string ComPort
        {
            get { return ConfigurationManager.AppSettings["ComPort"]; }
        }

        public string SecureDevice
        {
            get { return ConfigurationManager.AppSettings["SecureDevice"]; }
        }


        public string PrintReceiptMessageMethod4
        {
            get { return "{0}TranCode=PrintReceipt&OperatorID=danotest&MerchantID=NONE&ComPort=0&TStream=Admin&SecureDevice=NONE{1}"; }
        }

        public string PrintPoleDisplayMessageMethod4
        {
            get {return "{0}TranCode=PoleDisplay&OperatorID=danotest&MerchantID=NONE&ComPort=0&TStream=Admin&SecureDevice=NONE{1}";}
        }

        public string CashDrawerMessageMethod4
        {
            get {return "{0}TranCode=DrawerOpen&OperatorID=danotest&MerchantID=494901&ComPort=0&TStream=Admin&SecureDevice=ONTRAN";}
        }

        public string SaleMessageMethod4
        {
            get { return "{0}TranType={1}&TranCode=Sale&OperatorID=test&MerchantID={2}&ComPort={3}&TStream=Transaction&SecureDevice={4}&InvoiceNo=123&RefNo=123&AcctNo=SecureDevice&Purchase={5}{6}"; }
        }

        public string PrintReceiptMessageMethod1
        {
            get { return "<?xml version=\"1.0\"?><TStream><Admin>{0}<TranCode>PrintReceipt</TranCode><MerchantID>494901</MerchantID><ComPort>0</ComPort><SecureDevice>ONTRAN</SecureDevice>{1}</Admin></TStream>"; }            
        }

        public string PrintPoleDisplayMessageMethod1
        {
            get { return "<?xml version=\"1.0\"?><TStream><Admin>{0}<TranCode>PoleDisplay</TranCode><MerchantID>494901</MerchantID><ComPort>0</ComPort><SecureDevice>ONTRAN</SecureDevice>{1}</Admin></TStream>"; }
        }

        public string CashDrawerMessageMethod1
        {
            get { return "<?xml version=\"1.0\"?><TStream><Admin>{0}<TranCode>DrawerOpen</TranCode><MerchantID>494901</MerchantID><ComPort>0</ComPort><SecureDevice>ONTRAN</SecureDevice></Admin></TStream>"; }
        }

        public string SaleMessageMethod1
        {
            get { return "<?xml version=\"1.0\"?><TStream><Transaction>{0}<TranType>{1}</TranType><MerchantID>{2}</MerchantID><ComPort>{3}</ComPort><SecureDevice>{4}</SecureDevice><OperatorID>danotest</OperatorID><TranCode>Sale</TranCode><InvoiceNo>123</InvoiceNo><RefNo>123</RefNo><Account><AcctNo>SecureDevice</AcctNo></Account><Purchase>{5}</Purchase>{6}</Transaction></TStream>"; }
        }

        public string RecordNoFrequencyMethod1
        {
            get { return "<RecordNo>RecordNumberRequested</RecordNo><Frequency>OneTime</Frequency>"; }
        }

        public string RecordNoFrequencyMethod4
        {
            get { return "&RecordNo=RecordNumberRequested&Frequency=OneTime"; }
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