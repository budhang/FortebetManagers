using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FortebetManagers.Models
{
    public class RegisterElectronics  
    {
        public int ID { get; set; }
        public int ElectronicsID { get; set; }
        public Electronics Electronics { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Serial number")]
        public string SerialNumber { get; set; }
        public decimal Price { get; set; }
        public string Supplier { get; set; }
        [Display(Name = "Invoice Number")]
        public string Invoice { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Purchased")]
        public DateTime DatePurchased { get; set; }
        
       
        
       
    }
}
