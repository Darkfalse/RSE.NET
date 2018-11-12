using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _WebApp.Areas.Admin.Models.Formulaires {
    public class EditProjetForm {

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(250)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateDebut { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateFin { get; set; }
    }
}