namespace Crosshelper.Models
{
    public class UserPro
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ChatID { get; set; }
        public string FLanguage { get; set; }
        public string SLanguage { get; set; }
        public string PaymentID { get; set; }
        public string Icon { get; set; }
        public string Location { get; set; }
        public int Rating { get; set; }
        public int Status { get; set; }
        public string PriceSign { get; set; }
        public string UserID { get; internal set; }
        public string Bio { get; internal set; }
        public string ZipCode { get; internal set; }
    }
}
