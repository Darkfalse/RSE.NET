using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Mappers
{
    internal static class Mappers
    {

        internal static Administrateur ToAdministrateur(this IDataRecord dr)
        {
            return new Administrateur()
            {
                Id = (int) dr["Id_Admin"],
                Employee = (int) dr["Id_Employee"],
                NumeroAdmin = (int) dr["Numero_Admin"]
            };
        }
        internal static Adresse ToAdresse(this IDataRecord dr)
        {
            return new Adresse()
            {
                Boite_Postal = dr["Boite_Postal"] == DBNull.Value ? null : (string) dr["Boite_Postal"],
                Id = (int) dr["Id_Adresse"],
                Id_Ville = (int) dr["Id_Ville"],
                Nom_Rue = (string) dr["Nom_Rue"]
            };
        }
        internal static Coordonnee ToCoordonnee(this IDataRecord dr)
        {
            return new Coordonnee()
            {
                Id = (int) dr["Id_Coordonee"],
                Latitude = (string) dr["Latitude"],
                Longitude = (string) dr["Longitude"]
            };
        }
        internal static Departement ToDepartement(this IDataRecord dr)
        {
            return new Departement()
            {
                Admin = (int) dr["Id_Admin"],
                Description = (string) dr["Description"],
                Id = (int) dr["Id_Departement"],
                Nom = (string) dr["Nom_Departement"]
            };
        }
        internal static Document ToDocument(this IDataRecord dr)
        {
            return new Document()
            {
                Date = (DateTime) dr["Date"],
                Description = (string) dr["Description"],
                Format = (string) dr["Format"],
                Id = (int) dr["Id_Document"],
                Id_Emp_Creee = (int) dr["Id_Employee_Cree"],
                Id_Emp_Maj = (int) dr["Id_Employee_Maj"],
                Lien = (string) dr["Lien"],
                Nom = (string) dr["Nom_Document"],
                Taille = (float) dr["Taille"]
            };
        }
        internal static Employee ToEmployee(this IDataRecord dr)
        {
            return new Employee()
            {
                Adresse = dr["Id_Adresse"] == DBNull.Value ? 0 : (int) dr["Id_Adresse"],
                Birthday = (DateTime) dr["Birthday"],
                Coordonnee = dr["Id_Coordonee"] == DBNull.Value ? 0 : (int) dr["Id_Coordonee"],
                Email = (string) dr["Email"],
                HireDate = (DateTime) dr["HireDate"],
                Id = (int) dr["Id_Employee"],
                Nom = (string) dr["Nom_Employee"],
                Password = null,
                Prenom = (string) dr["Prenom"],
                RegNat = (string) dr["RegNat"],
                Tel = (string) dr["Tel"],
                Valide = (bool) dr["Valide"]
            };
        }
        internal static StatutEmployee ToStatutEmployee(this IDataRecord dr)
        {
            return new StatutEmployee()
            {
                Id = (int) dr["Id_Employee_Statut"],
                NomStatut = (string) dr["Nom_Employee_Statut"]
            };
        }
        internal static Equipe ToEquipe(this IDataRecord dr)
        {
            return new Equipe()
            {
                Creee = (DateTime) dr["Date_Creation_Equipe"],
                Id = (int) dr["Id_Equipe"],
                Nom = (string) dr["Nom_Equipe"],
                Projet = (int) dr["Id_Projet"]
            };
        }
        internal static Event ToEvent(this IDataRecord dr)
        {
            return new Event()
            {
                DateDebut = (DateTime) dr["Date_Debut"],
                DateFin = (DateTime) dr["Date_Fin"],
                Description = (string) dr["Description"],
                FullDay = (bool) dr["FullDay"],
                Id = (int) dr["Id_Event"],
                Id_Employee = (int) dr["Id_Employee"],
                Lieu = (int) dr["Lieu"],
                Nom = (string) dr["Nom_Event"]
            };
        }
        internal static MessageEmployee ToMessageEmployee(this IDataRecord dr)
        {
            return new MessageEmployee()
            {
                Contenu = (string) dr["Texte_Message_Employee"],
                Date = (DateTime) dr["Date_Message_Employee"],
                Id = (int) dr["Id_Message_Employee"],
                Id_Employee = (int) dr["Id_Employee"],
                Id_Destinataire = (int) dr["Id_Employee_Destinataire"],
                MessagePrecedent = dr["Id_Message"] == DBNull.Value ? 0 : (int) dr["Id_Message"],
                Titre = (string) dr["Titre_Message_Employee"]
            };
        }
        internal static MessageEquipe ToMessageEquipe(this IDataRecord dr)
        {
            return new MessageEquipe()
            {
                Contenu = (string) dr["Texte_Message_Equipe"],
                Date = (DateTime) dr["Date_Message_Equipe"],
                Id = (int) dr["Id_Message_Equipe"],
                Id_Equipe = (int) dr["Id_Equipe"],
                MessagePrecedent = dr["Id_Message"] == DBNull.Value ? 0 : (int) dr["Id_Message"],
                Titre = (string) dr["Titre_Message_Equipe"],
                Id_Employee = (int) dr["Id_Employee"]
            };
        }
        internal static MessageProjet ToMessageProjet(this IDataRecord dr)
        {
            return new MessageProjet()
            {
                Contenu = (string) dr["Texte_Message_Projet"],
                Date = (DateTime) dr["Date_Message_Projet"],
                Id = (int) dr["Id_Message_Projet"],
                MessagePrecedent = dr["Id_Message"] == DBNull.Value ? 0 : (int) dr["Id_Message"],
                Titre = (string) dr["Titre_Message_Projet"],
                Id_Employee = (int) dr["Id_Employee"],
                Id_Projet = (int) dr["Id_Projet"]
            };
        }
        internal static MessageTache ToMessageTache(this IDataRecord dr)
        {
            return new MessageTache()
            {
                Contenu = (string) dr["Texte_Message_Tache"],
                Date = (DateTime) dr["Date_Message_Tache"],
                Id = (int) dr["Id_Message_Tache"],
                MessagePrecedent = dr["Id_Message"] == DBNull.Value ? 0 : (int) dr["Id_Message"],
                Titre = (string) dr["Titre_Message_Tache"],
                Id_Employee = (int) dr["Id_Employee"],
                Id_Tache_Emplopyee = dr["Id_Tache_Employee"] == DBNull.Value ? 0 : (int) dr["Id_Tache_Employee"],
                Id_Tache_Equipe = dr["Id_Tache_Equipe"] == DBNull.Value ? 0 : (int) dr["Id_Tache_Equipe"]
            };
        }
        internal static Pays ToPays(this IDataRecord dr)
        {
            return new Pays()
            {
                Alpha2 = (string) dr["Alpha2"],
                Alpha3 = (string) dr["Alpha3"],
                Code = (int) dr["Code"],
                Id = (int) dr["Id_Pays"],
                Nom_EN = (string) dr["Nom_International"],
                Nom_FR = (string) dr["Nom_Francais"]
            };
        }

        internal static Projet ToProjet(this IDataRecord dr)
        {
            return new Projet()
            {
                Admin = (int) dr["Id_Admin"],
                Debut = (DateTime) dr["Date_Debut"],
                Description = (string) dr["Description"],
                Fin = dr["Date_Fin"] == DBNull.Value ? null : (DateTime?) dr["Date_Fin"],
                Id = (int) dr["Id_Projet"],
                Nom = (string) dr["Nom_Projet"]
            };
        }

        internal static TacheEmployee ToTacheEmployee(this IDataRecord dr)
        {
            return new TacheEmployee()
            {
                Debut = (DateTime) dr["Date_Debut"],
                Description = (string) dr["Description_Tache_Employee"],
                Fin = dr["Date_Fin"] == DBNull.Value ? null : (DateTime?) dr["Date_Fin"],
                Final = dr["Date_Final"] == DBNull.Value ? null : (DateTime?) dr["Date_Final"],
                Id = (int) dr["Id_Tache_Employee"],
                Nom = (string) dr["Nom_Tache_Employee"],
                Projet = (int) dr["Id_Projet"],
                TachePrecedente = dr["Tache_Precedente"] == DBNull.Value ? 0 : (int?) dr["Tache_Precedente"]
            };
        }
        internal static TacheEquipe ToTacheEquipe(this IDataRecord dr)
        {
            return new TacheEquipe()
            {
                Debut = (DateTime) dr["Date_Debut"],
                Description = (string) dr["Description_Tache_Equipe"],
                Fin = dr["Date_Fin"] == DBNull.Value ? null : (DateTime?)dr["Date_Fin"],
                Final = dr["Date_Final"] == DBNull.Value ? null : (DateTime?)dr["Date_Final"],
                Id = (int) dr["Id_Tache_Equipe"],
                Nom = (string) dr["Nom_Tache_Equipe"],
                Projet = (int) dr["Id_Projet"],
                TachePrecedente = dr["Tache_Precedente"] == DBNull.Value ? 0 : (int?)dr["Tache_Precedente"]
            };
        }

        internal static StatutTache ToStatutTache(this IDataRecord dr)
        {
            return new StatutTache()
            {
                Id = (int) dr["Id_Tache_Statut"],
                NomStatut = (string) dr["Nom_Tache_Statut"]
            };
        }

        internal static Ville ToVille(this IDataRecord dr)
        {
            return new Ville()
            {
                Id = (int) dr["Id_Ville"],
                Id_Pays = (int) dr["Id_Pays"],
                Nom = (string) dr["Nom_Ville"],
                Zip = (string) dr["Zip"]
            };
        }

    }
}