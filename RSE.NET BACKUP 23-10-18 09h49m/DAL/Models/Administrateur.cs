using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class Administrateur
    {
        public int Id { get; set; }
        public int NumeroAdmin { get; set; }
        public Employee Employee  { get; set; }
    }
}
