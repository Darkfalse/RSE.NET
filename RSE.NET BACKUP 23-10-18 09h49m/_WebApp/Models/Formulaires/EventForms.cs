using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _WebApp.Models.Formulaires
{
    public class EventForms
    {
        [Required][MaxLength(50)]
        public string Nom { get; set; }


        [Required]
        [MaxLength(250)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        public int Lieu { get; set; }
    
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        [Display(Name = "Date de début")]
        public DateTime DateDebut { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de début")]
        public DateTime DateFin { get; set; }

        [Range(typeof(bool), "true", "false")]
        public bool FullDay { get; set; }

        [Required]
        public int Id_Employee { get; set; }
    }
}