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

        public Coordonnee(string lon, string lat) {
            Longitude = lon;
            Latitude = lat;
        }

        public Coordonnee(int? id, string lon, string lat) : this(lon, lat) {
            Id = id;
        }
    }
}
