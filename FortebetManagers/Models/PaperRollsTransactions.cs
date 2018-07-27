using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FortebetManagers.Models
{
    public class PaperRollsTransactions 
    {
        public int Id { get; set; }
        public string Source { get; set; }
        [Display(Name="Destination")]
        public int ShopsId{ get; set; }
        public Shops Shops { get; set; }
        public double? Quantity { get; set; }
       
        
    }
}
