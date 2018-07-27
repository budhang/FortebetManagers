using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortebetManagers.Models
{
    public class Catridges
    {
      public int ID { get; set; }
      public int ShopID { get; set; }
      public Shops Shops { get; set; }
     
    }
}
