using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class StatutEmployee
    {
        public int? Id { get; private set; }
        public string NomStatut { get; set; }

        public StatutEmployee(string nom) {
            NomStatut = nom;
        }

        public StatutEmployee(int? id, string nom) : this(nom) {
            Id = id;
        }
    }
}
