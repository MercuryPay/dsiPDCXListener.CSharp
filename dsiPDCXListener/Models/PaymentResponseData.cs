using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dsiPDCXListener.Models
{
    public class PaymentResponseData
    {
        public string ResponseOrigin {get;set;}
        public string DSIXReturnCode {get;set;}
        public string CmdStatus {get;set;}
        public string TextResponse {get;set;}
        public string MerchantID {get;set;}
        public string AcctNo {get;set;}
        public string CardType {get;set;}
        public string TranCode {get;set;}
        public string AuthCode {get;set;}
        public string CaptureStatus {get;set;}
        public string RefNo {get;set;}
        public string InvoiceNo {get;set;}
        public string Purchase {get;set;}
        public string Authorize {get;set;}
        public string RecordNo { get; set; }
    }
}