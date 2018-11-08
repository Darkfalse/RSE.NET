using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _WebApp.Models.Formulaires {
    public class SujetForm {

        [Required]
        [MaxLength(50)]
        public string Titre { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Message { get; set; }
    }
}