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
                Boite_Postal = (string) dr["Boite_Postal"],
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
                Adresse = (int) dr["Id_Adresse"],
                Birthday = (DateTime) dr["Birthday"],
                Coordonnee = (int) dr["Id_Coordonee"],
                Email = (string) dr["Email"],
                HireDate = (DateTime) dr["HireDate"],
                Id = (int) dr["Id_Employee"],
                Nom = (string) dr["Nom_Employee"],
                Password = null,
                Prenom = (string) dr["Prenom"],
                RegNat = (string) dr["RegNat"],
                Tel = (string) dr["Tel"]
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

            };
    }
    }
}