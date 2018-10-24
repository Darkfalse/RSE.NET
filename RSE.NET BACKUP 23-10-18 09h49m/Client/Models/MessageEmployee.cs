﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class MessageEmployee
    {
        public int? Id { get; private set; }
        public string Titre { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }
        public int? MessagePrecedent { get; set; }
        public int Id_Employee { get; set; }
        public int Id_Destinataire { get; set; }
    }
}
