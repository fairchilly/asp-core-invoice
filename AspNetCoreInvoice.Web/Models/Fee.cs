namespace AspNetCoreInvoice.Web.Models
{
    public class Fee
    {
        public string Description { get; set; }
        public string PercentageOrPrice { get; set; }
        public decimal Value { get; set; }
    }
}