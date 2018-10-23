using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    public class Document {
        public int? Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Lien { get; set; }
        public float Taille { get; set; }
        public string Format { get; set; }
        public int Id_Emp_Creee { get; set; }
        public int Id_Emp_Maj { get; set; }
    }
}
