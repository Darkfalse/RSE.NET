using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
   public class Departement
   {
        public int? Id { get; private set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int Admin { get; set; }
    }
}
