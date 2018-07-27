using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FortebetManagers.Models
{
    public class RegisterOfficeItems
    {
        public int ID { get; set; }
        [Required]
        public string Item { get; set; }
        [Required]
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
