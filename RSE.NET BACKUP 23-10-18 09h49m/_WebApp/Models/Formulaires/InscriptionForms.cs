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
        [MaxLength(249)]
        public string Email { get; set; }

        [Required]
        [MaxLength(19)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [MaxLength(20)]
        public string RegNat { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nom_Rue { get; set; }

        [MaxLength(5)]
        public string Boite_Postal { get; set; }

        [Required]
        public string Ville { get; set; }

        [Required]
        [MaxLength(7)]
        public string Zip { get; set; }

        [Required]
        public string Pays { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [Required]
        [MaxLength(25)]
        public string Tel { get; set; }
    }
}