using C = Client.Models;
using D = DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Mappers
{
    internal static class Mappers
    {
        internal static D.Projet ToDal(this C.Projet entity)
        {
            return new D.Projet()
            {
                Id = entity.Id,
                Admin = entity.Admin,
                Debut = entity.Debut,
                Description = entity.Description,
                Fin = entity.Fin,
                Nom = entity.Nom
            };
        }

        internal static D.Administrateur ToDal(this C.Administrateur entity)
        {
            return new D.Administrateur()
            {
                Employee = entity.Employee,
                Id = entity.Id,
                NumeroAdmin = entity.NumeroAdmin
            };
        }

        internal static D.Employee ToDal(this C.Employee entity)
        {
            return new D.Employee()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Adresse = entity.Adresse,
                Birthday = entity.Birthday,
                Coordonnee = entity.Coordonnee,
                Email = entity.Email,
                HireDate = entity.HireDate,
                Password = entity.Password,
                Prenom = entity.Prenom,
                RegNat = entity.RegNat,
                Tel = entity.Tel
            };
        }

        internal static D.Adresse ToDal(this C.Adresse entity)
        {
            return new D.Adresse()
            {
                Boite_Postal = entity.Boite_Postal,
                Id = entity.Id,
                Id_Ville = entity.Id_Ville,
                Nom_Rue = entity.Nom_Rue,
            };
        }

        internal static D.Coordonnee ToDal(this C.Coordonnee entity)
        {
            return new D.Coordonnee()
            {
                Id = entity.Id,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
            };
        }

        internal static D.Departement ToDal(this C.Departement entity)
        {
            return new D.Departement()
            {
                Admin = entity.Admin,
                Description = entity.Description,
                Id = entity.Id,
                Nom = entity.Nom
            };
        }

        internal static D.Document ToDal(this C.Document entity)
        {
            return new D.Document()
            {
                Date = entity.Date,
                Description = entity.Description,
                Format = entity.Format,
                Id = entity.Id,
                Id_Emp_Creee = entity.Id_Emp_Creee,
                Id_Emp_Maj = entity.Id_Emp_Maj,
                Lien = entity.Lien,
                Nom = entity.Nom,
                Taille = entity.Taille
            };
        }

        internal static D.Equipe ToDal(this C.Equipe entity)
        {
            return new D.Equipe()
            {
                Creee = entity.Creee,
                Id = entity.Id,
                Nom = entity.Nom,
                Projet = entity.Projet
            };
        }

        internal static D.Event ToDal(this C.Event entity)
        {
            return new D.Event()
            {
                DateDebut = entity.DateDebut,
                Id = entity.Id,
                Nom = entity.Nom,
                Description = entity.Description,
                Id_Employee = entity.Id_Employee,
                Lieu = entity.Lieu,
                DateFin = entity.DateFin,
                FullDay = entity.FullDay
            };
        }

        internal static D.MessageEmployee ToDal(this C.MessageEmployee entity)
        {
            return new D.MessageEmployee()
            {
                Contenu = entity.Contenu,
                Id = entity.Id,
                Id_Employee = entity.Id_Employee,
                Date = entity.Date,
                MessagePrecedent = entity.MessagePrecedent,
                Id_Destinataire = entity.Id_Destinataire,
                Titre = entity.Titre
            };
        }

        internal static D.MessageEquipe ToDal(this C.MessageEquipe entity)
        {
            return new D.MessageEquipe()
            {
                Contenu = entity.Contenu,
                Id = entity.Id,
                Id_Equipe = entity.Id_Equipe,
                Date = entity.Date,
                MessagePrecedent = entity.MessagePrecedent,
                Titre = entity.Titre,
                Id_Employee = entity.Id_Employee
            };
        }

        internal static D.MessageProjet ToDal(this C.MessageProjet entity)
        {
            return new D.MessageProjet()
            {
                Contenu = entity.Contenu,
                Id = entity.Id,
                Id_Projet = entity.Id_Projet,
                Date = entity.Date,
                MessagePrecedent = entity.MessagePrecedent,
                Titre = entity.Titre,
                Id_Employee = entity.Id_Employee
            };
        }
        internal static D.MessageTache ToDal(this C.MessageTache entity)
        {
            return new D.MessageTache()
            {
                Contenu = entity.Contenu,
                Id = entity.Id,
                Date = entity.Date,
                MessagePrecedent = entity.MessagePrecedent,
                Titre = entity.Titre,
                Id_Employee = entity.Id_Employee,
                Id_Tache_Emplopyee = entity.Id_Tache_Emplopyee,
                Id_Tache_Equipe = entity.Id_Tache_Equipe
            };
        }

        internal static D.Pays ToDal(this C.Pays entity)
        {
            return new D.Pays()
            {
                Id = entity.Id,
                Nom_FR = entity.Nom_FR,
                Nom_EN = entity.Nom_EN,
                Code = entity.Code,
                Alpha2 = entity.Alpha2,
                Alpha3 = entity.Alpha3
            };
        }

        internal static D.StatutEmployee ToDal(this C.StatutEmployee entity)
        {
            return new D.StatutEmployee()
            {
                Id = entity.Id,
                NomStatut = entity.NomStatut,
            };
        }
        internal static D.StatutTache ToDal(this C.StatutTache entity)
        {
            return new D.StatutTache()
            {
                Id = entity.Id,
                NomStatut = entity.NomStatut,
            };
        }

        internal static D.TacheEmployee ToDal(this C.TacheEmployee entity)
        {
            return new D.TacheEmployee()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Projet = entity.Projet,
                Description = entity.Description,
                Debut = entity.Debut,
                Fin = entity.Fin,
                Final = entity.Final,
                TachePrecedente = entity.TachePrecedente
            };
        }
        internal static D.TacheEquipe ToDal(this C.TacheEquipe entity)
        {
            return new D.TacheEquipe()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Projet = entity.Projet,
                Description = entity.Description,
                Debut = entity.Debut,
                Fin = entity.Fin,
                Final = entity.Final,
                TachePrecedente = entity.TachePrecedente
            };
        }

        internal static D.Ville ToDal(this C.Ville entity)
        {
            return new D.Ville()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Id_Pays = entity.Id_Pays,
                Zip = entity.Zip
            };
        }


        //internal static C.Projet ToClient(this D.Projet entity)
        //{
        //    return new C.Projet(entity.);
        //}
    }
}