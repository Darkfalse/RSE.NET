using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Coordonnee
    {
        public int? Id { get; private set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
