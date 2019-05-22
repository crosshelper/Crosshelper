namespace Crosshelper.Models
{
    public class ReceiptInfo
    {
        public string CaseID { get; set; }
        public double ServiceFee { get; set; }
        public double EqFee { get; set; }
        public double Tax { get; set; }
        public double Surcharge { get; set; }
        public string PaymentDateTime { get; set; }
        public string PaymentName { get; set; }
    }
}
