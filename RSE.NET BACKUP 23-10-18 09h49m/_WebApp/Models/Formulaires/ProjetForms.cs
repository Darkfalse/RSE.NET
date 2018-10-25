using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _WebApp.Models.Formulaires
{
    public class ProjetForms
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        [MaxLength(250)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Debut { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Fin { get; set; }

        public int? Admin { get; set; }





    }
}