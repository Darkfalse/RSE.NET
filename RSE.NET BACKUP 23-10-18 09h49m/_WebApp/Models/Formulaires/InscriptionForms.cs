using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _WebApp.Models.Formulaires
{
    public class InscriptionForms
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        [DefaultValue("Entrez votre nom ici !")]
        public string Nom { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        [DefaultValue("Entrez votre prenom ici !")]
        public string Prenom { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string RegNat { get; set; }

        [Required]
        public string Nom_Rue { get; set; }

        [MaxLength]
        public string Boite_Postal { get; set; }

        [Required]
        public string Ville { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string Pays { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public string Tel { get; set; }
    }
}