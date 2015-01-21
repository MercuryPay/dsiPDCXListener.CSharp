using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dsiPDCXListener.Models
{
    public class AdminData
    {
        public string PostURL {get;set;}
        public string TranDeviceID {get;set;}
        public string PostURLMethod { get; set; }
        public string ComPort { get; set; }
        public string SecureDevice { get; set; }
        public string MerchantID { get; set; }
        public bool IncludeRecordNoAndFrequency { get; set; }
    }
}