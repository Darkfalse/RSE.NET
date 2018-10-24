using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Administrateur
    {
        public int Id { get; private set; }
        public int NumeroAdmin { get; set; }
        public int Employee  { get; set; }

        public Administrateur(int num, int em) {
            NumeroAdmin = num;
            Employee = em;
        }

        public Administrateur(int id, int num, int em) : this(num, em) {
            Id = id;
        }
    }
}
