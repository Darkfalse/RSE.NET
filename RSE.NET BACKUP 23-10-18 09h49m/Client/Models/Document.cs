using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
    public class Document
    {
        public int? Id { get; private set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Lien { get; set; }
        public float Taille { get; set; }
        public string Format { get; set; }
        public int Id_Emp_Creee { get; set; }
        public int Id_Emp_Maj { get; set; }

        public Document(string nom, string des, DateTime date, string lien, float taille, string format, int idEmpCree, int idEmpMaj) {
            Nom = nom;
            Description = des;
            Date = date;
            Lien = lien;
            Taille = taille;
            Format = format;
            Id_Emp_Creee = idEmpCree;
            Id_Emp_Maj = idEmpMaj;
        }

        public Document(int id, string nom, string des, DateTime date, string lien, float taille, string format, int idEmpCree, int idEmpMaj) : this(nom, des, date, lien, taille, format, idEmpCree, idEmpMaj) {
            Id = id;
        }
    }
}
