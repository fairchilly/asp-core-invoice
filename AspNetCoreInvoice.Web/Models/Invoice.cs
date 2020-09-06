using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreInvoice.Web.Models
{
    public class Invoice
    {
        public string Number { get; set; } = "00001";
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddMonths(1);
        public Address CompanyAddress { get; set; }
        public Address CustomerAddress { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Fee> Fees { get; set; } = new List<Fee>();

        public decimal SubTotal => Items.Sum(i => i.TotalCost);

        public Dictionary<string, decimal> CalculatedFees()
        {
            var calculatedFees = new Dictionary<string, decimal>();
            Fees.ForEach(i =>
            {
                if (i.Description != null)
                {
                    if (i.PercentageOrPrice == "Percentage")
                        calculatedFees.Add($"{i.Description} ( {i.Value}% )", SubTotal * (i.Value / 100));
                    else if (i.PercentageOrPrice == "Price")
                        calculatedFees.Add(i.Description, i.Value);
                }
            });

            return calculatedFees;
        }

        public decimal AmountDue() => SubTotal + CalculatedFees().Sum(f => f.Value);
    }
}