using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FortebetManagers.Models
{
    public class Source
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Source")]
        public string SourceP { get; set; }
    }
}
