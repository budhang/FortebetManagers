using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FortebetManagers.Models
{
    public class Electronics
    {
        public int ID { get; set; }
        [Required]
        public string Name { set; get; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Purchased")]
        public DateTime DatePurchased;
       }   
}
