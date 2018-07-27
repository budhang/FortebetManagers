using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FortebetManagers.Models
{
    public class Shops
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string District { get; set; }
        public string Sector { get; set; }
        public string Cell { get; set; }
        public string Village { get; set; }
        public string Landlord { get; set; }
        public Decimal Rent { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime DateRented { get; set; }
        

    }
}
