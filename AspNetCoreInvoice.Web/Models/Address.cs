using System.Collections.Generic;

namespace AspNetCoreInvoice.Web.Models
{
    public class Address
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }

        public string MergedAddressLine()
        {
            var line = City;
            if (State != null)
            {
                line += $", {State}";
            }

            if (ZipCode != null)
            {
                line += $" {ZipCode}";
            }
            
            return line;
        }
    }
}