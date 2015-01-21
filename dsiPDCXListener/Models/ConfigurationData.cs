using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dsiPDCXListener.Models
{
    public class ConfigurationData
    {
        public string MerchantName { get; set; }

        public string MerchantID { get; set; }

        public string MerchantAddress { get; set; }

        public string MerchantCity { get; set; }

        public string MerchantState { get; set; }

        public string MerchantPostalCode { get; set; }
        public string TranDeviceID { get; set; }
        public string PostURL { get; set; }
        public string PostURLMethod { get; set; }

        public string PrintReceiptMessage { get; set; }
        public string PrintPoleDisplayMessage { get; set; }
        public string CashDrawerMessage { get; set; }
        public string SaleMessage { get; set; }
        public string ContentType { get; set; }
        public string ComPort { get; set; }
        public string SecureDevice { get; set; }
        public string IncludeRecordNoAndFrequency { get; set; }

    }
}