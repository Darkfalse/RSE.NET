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
            if (dr != null) {
                return new Administrateur() {
                    Id = (int)dr["Id_Admin"],
                    Employee = (int)dr["Id_Employee"],
                    NumeroAdmin = (int)dr["Numero_Admin"]
                };
            }
            else
                return null;
        }
        internal static Adresse ToAdresse(this IDataRecord dr)
        {
            if (dr != null) {
                return new Adresse() {
                    Boite_Postal = dr["Boite_Postal"] == DBNull.Value ? null : (string)dr["Boite_Postal"],
                    Id = (int)dr["Id_Adresse"],
                    Id_Ville = (int)dr["Id_Ville"],
                    Nom_Rue = (string)dr["Nom_Rue"]
                };
            }
            else
                return null;
        }
        internal static Coordonnee ToCoordonnee(this IDataRecord dr)
        {
            if (dr != null) {
                return new Coordonnee() {
                    Id = (int)dr["Id_Coordonee"],
                    Latitude = (string)dr["Latitude"],
                    Longitude = (string)dr["Longitude"]
                };
            }
            else
                return null;
        }
        internal static Departement ToDepartement(this IDataRecord dr)
        {
            if (dr != null) {
                return new Departement() {
                    Admin = (int)dr["Id_Admin"],
                    Description = (string)dr["Description"],
                    Id = (int)dr["Id_Departement"],
                    Nom = (string)dr["Nom_Departement"]
                };
            }
            else
                return null;
        }
        internal static Document ToDocument(this IDataRecord dr)
        {
            if (dr != null)
            {
                Document d = new Document();

                d.Date = (DateTime) dr["Date"];
                d.Description = (string) dr["Description"];
                d.Format = (string) dr["Format"];
                d.Id = (int) dr["Id_Document"];
                d.Id_Emp_Creee = (int) dr["Id_Employee_Cree"];
                d.Id_Emp_Maj =  dr["Id_Employee_Maj"] as int?;
                d.Lien = (string) dr["Lien"];
                d.Nom = (string) dr["Nom_Document"];
                d.Taille = (double) dr["Taille"];

                return d;
            }
            else
                return null;
        }
        internal static Employee ToEmployee(this IDataRecord dr)
        {
            if (dr != null) {
                return new Employee() {
                    Adresse = dr["Id_Adresse"] == DBNull.Value ? 0 : (int)dr["Id_Adresse"],
                    Birthday = (DateTime)dr["Birthday"],
                    Coordonnee = dr["Id_Coordonee"] == DBNull.Value ? 0 : (int)dr["Id_Coordonee"],
                    Email = (string)dr["Email"],
                    HireDate = (DateTime)dr["HireDate"],
                    Id = (int)dr["Id_Employee"],
                    Nom = (string)dr["Nom_Employee"],
                    Password = null,
                    Prenom = (string)dr["Prenom"],
                    RegNat = (string)dr["RegNat"],
                    Tel = (string)dr["Tel"],
                    Valide = (bool)dr["Valide"]
                };
            }
            else
                return null;
        }
        internal static StatutEmployee ToStatutEmployee(this IDataRecord dr)
        {
            if (dr != null) {
                return new StatutEmployee() {
                    Id = (int)dr["Id_Employee_Statut"],
                    NomStatut = (string)dr["Nom_Employee_Statut"]
                };
            }
            else
                return null;
        }
        internal static Equipe ToEquipe(this IDataRecord dr)
        {
            if (dr != null) {
                return new Equipe() {
                    Creee = (DateTime)dr["Date_Creation_Equipe"],
                    Id = (int)dr["Id_Equipe"],
                    Nom = (string)dr["Nom_Equipe"],
                    Projet = (int)dr["Id_Projet"]
                };
            }
            else
                return null;
        }
        internal static Event ToEvent(this IDataRecord dr)
        {
            if (dr != null) {
                return new Event() {
                    DateDebut = (DateTime)dr["Date_Debut"],
                    DateFin = (DateTime)dr["Date_Fin"],
                    Description = (string)dr["Description"],
                    FullDay = (bool)dr["FullDay"],
                    Id = (int)dr["Id_Event"],
                    Id_Employee = (int)dr["Id_Employee"],
                    Lieu = (int)dr["Lieu"],
                    Nom = (string)dr["Nom_Event"]
                };
            }
            else
                return null;
        }
        internal static MessageEmployee ToMessageEmployee(this IDataRecord dr)
        {
            if (dr != null) {
                return new MessageEmployee() {
                    Contenu = (string)dr["Texte_Message_Employee"],
                    Date = (DateTime)dr["Date_Message_Employee"],
                    Id = (int)dr["Id_Message_Employee"],
                    Id_Employee = (int)dr["Id_Employee"],
                    Id_Destinataire = (int)dr["Id_Employee_Destinataire"],
                    MessagePrecedent = dr["Id_Message"] == DBNull.Value ? 0 : (int)dr["Id_Message"],
                    Titre = (string)dr["Titre_Message_Employee"]
                };
            }
            else
                return null;
        }
        internal static MessageEquipe ToMessageEquipe(this IDataRecord dr)
        {
            if (dr != null) {
                return new MessageEquipe() {
                    Contenu = (string)dr["Texte_Message_Equipe"],
                    Date = (DateTime)dr["Date_Message_Equipe"],
                    Id = (int)dr["Id_Message_Equipe"],
                    Id_Equipe = (int)dr["Id_Equipe"],
                    MessagePrecedent = dr["Id_Message"] == DBNull.Value ? 0 : (int)dr["Id_Message"],
                    Titre = (string)dr["Titre_Message_Equipe"],
                    Id_Employee = (int)dr["Id_Employee"]
                };
            }
            else
                return null;
        }
        internal static MessageProjet ToMessageProjet(this IDataRecord dr)
        {
            if (dr != null) {
                return new MessageProjet() {
                    Contenu = (string)dr["Texte_Message_Projet"],
                    Date = (DateTime)dr["Date_Message_Projet"],
                    Id = (int)dr["Id_Message_Projet"],
                    MessagePrecedent = dr["Id_Message"] == DBNull.Value ? 0 : (int)dr["Id_Message"],
                    Titre = (string)dr["Titre_Message_Projet"],
                    Id_Employee = (int)dr["Id_Employee"],
                    Id_Projet = (int)dr["Id_Projet"]
                };
            }
            else
                return null;
        }
        internal static MessageTache ToMessageTache(this IDataRecord dr)
        {
            if (dr != null) {
                return new MessageTache() {
                    Contenu = (string)dr["Texte_Message_Tache"],
                    Date = (DateTime)dr["Date_Message_Tache"],
                    Id = (int)dr["Id_Message_Tache"],
                    MessagePrecedent = dr["Id_Message"] == DBNull.Value ? 0 : (int)dr["Id_Message"],
                    Titre = (string)dr["Titre_Message_Tache"],
                    Id_Employee = (int)dr["Id_Employee"],
                    Id_Tache_Employee = dr["Id_Tache_Employee"] == DBNull.Value ? 0 : (int)dr["Id_Tache_Employee"],
                    Id_Tache_Equipe = dr["Id_Tache_Equipe"] == DBNull.Value ? 0 : (int)dr["Id_Tache_Equipe"]
                };
            }
            else
                return null;
        }
        internal static Pays ToPays(this IDataRecord dr)
        {
            if (dr != null) {
                return new Pays() {
                    Alpha2 = (string)dr["Alpha2"],
                    Alpha3 = (string)dr["Alpha3"],
                    Code = (int)dr["Code"],
                    Id = (int)dr["Id_Pays"],
                    Nom_EN = (string)dr["Nom_International"],
                    Nom_FR = (string)dr["Nom_Francais"]
                };
            }
            else
                return null;
        }

        internal static Projet ToProjet(this IDataRecord dr)
        {
            if (dr != null) {
                return new Projet() {
                    Admin = (int)dr["Id_Admin"],
                    Debut = (DateTime)dr["Date_Debut"],
                    Description = (string)dr["Description"],
                    Fin = dr["Date_Fin"] == DBNull.Value ? null : (DateTime?)dr["Date_Fin"],
                    Id = (int)dr["Id_Projet"],
                    Nom = (string)dr["Nom_Projet"]
                };
            }
            else
                return null;
        }

        internal static TacheEmployee ToTacheEmployee(this IDataRecord dr)
        {
            if (dr != null) {
                return new TacheEmployee() {
                    Debut = (DateTime)dr["Date_Debut"],
                    Description = (string)dr["Description_Tache_Employee"],
                    Fin = dr["Date_Fin"] == DBNull.Value ? null : (DateTime?)dr["Date_Fin"],
                    Final = dr["Date_Final"] == DBNull.Value ? null : (DateTime?)dr["Date_Final"],
                    Id = (int)dr["Id_Tache_Employee"],
                    Nom = (string)dr["Nom_Tache_Employee"],
                    Projet = (int)dr["Id_Projet"],
                    TachePrecedente = dr["Tache_Precedente"] == DBNull.Value ? 0 : (int?)dr["Tache_Precedente"]
                };
            }
            else
                return null;
        }
        internal static TacheEquipe ToTacheEquipe(this IDataRecord dr)
        {
            if (dr != null) {
                return new TacheEquipe() {
                    Debut = (DateTime)dr["Date_Debut"],
                    Description = (string)dr["Description_Tache_Equipe"],
                    Fin = dr["Date_Fin"] == DBNull.Value ? null : (DateTime?)dr["Date_Fin"],
                    Final = dr["Date_Final"] == DBNull.Value ? null : (DateTime?)dr["Date_Final"],
                    Id = (int)dr["Id_Tache_Equipe"],
                    Nom = (string)dr["Nom_Tache_Equipe"],
                    Projet = (int)dr["Id_Projet"],
                    TachePrecedente = dr["Tache_Precedente"] == DBNull.Value ? 0 : (int?)dr["Tache_Precedente"]
                };
            }
            else
                return null;
        }

        internal static StatutTache ToStatutTache(this IDataRecord dr)
        {
            if (dr != null) {
                return new StatutTache() {
                    Id = (int)dr["Id_Tache_Statut"],
                    NomStatut = (string)dr["Nom_Tache_Statut"]
                };
            }
            else
                return null;
        }

        internal static Ville ToVille(this IDataRecord dr)
        {
            if (dr != null) {
                return new Ville() {
                    Id = (int)dr["Id_Ville"],
                    Id_Pays = (int)dr["Id_Pays"],
                    Nom = (string)dr["Nom_Ville"],
                    Zip = (string)dr["Zip"]
                };
            }
            else
                return null;
        }
    }
}