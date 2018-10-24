using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Event
    {
        public int? Id { get; private set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int Lieu { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public bool FullDay { get; set; }
        public int Id_Employee { get; set; }

        public Event(string nom, string des, int lieu, DateTime debut, DateTime fin, bool fullday, int idemp) {
            Nom = nom;
            Description = des;
            Lieu = lieu;
            DateDebut = debut;
            DateFin = fin;
            FullDay = fullday;
            Id_Employee = idemp;
        }

        public Event(int id, string nom, string des, int lieu, DateTime debut, DateTime fin, bool fullday, int idemp) : this(nom, des, lieu, debut, fin, fullday, idemp) {
            Id = id;
        }
    }
}
