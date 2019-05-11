using System;

namespace Crosshelper.Models
{
    public class CaseInfo
    {
        public string CaseID { get; set; }
        public string CustomerID { get; set; }
        public string HelperID { get; set; }
        public string ReceiptID { get; set; }
        public string CaseType { get; set; }
        public DateTime CaseDateTime { get; set; }
        public string CaseDescription { get; set; }
        public string CaseTypeLabelText { get; internal set; }
        public string HelperName { get; internal set; }
    }
}
