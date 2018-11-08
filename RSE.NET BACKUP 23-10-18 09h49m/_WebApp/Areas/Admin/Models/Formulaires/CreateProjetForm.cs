using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _WebApp.Areas.Admin.Models.Formulaires {
    public class CreateProjetForm {

        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
    }
}