using System.ComponentModel.DataAnnotations;

namespace AspNetCoreInvoice.Web.Models
{
    public class Item
    {
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Units/Hours is required")]
        public decimal Units { get; set; }
        
        [Required(ErrorMessage = "Price Per Unit/Hour is required")]
        public decimal PricePerUnit { get; set; }

        public decimal TotalCost => Units * PricePerUnit;
    }
}