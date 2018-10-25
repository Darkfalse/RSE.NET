using DAL.Models;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using System.Configuration;

namespace DAL.Services {
    public class ProjetService {

        private readonly string providerName = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<Projet> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Projet;");

            return connection.ExecuteReader(command, (dr) => dr.ToProjet());
        }

        public Projet GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Projet WHERE Id_Projet = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToProjet()).SingleOrDefault();
        }

        public Projet Insert(Projet p) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Projet (Nom_Projet, Description, Date_Debut, Date_Fin, Id_Admin) OUTPUT INSERTED.ID VALUES (@nt, @d, @dd, @df, @ia);");
            command.AddParameter("np", p.Nom);
            command.AddParameter("d", p.Description);
            command.AddParameter("dd", p.Debut);
            command.AddParameter("df", p.Fin);
            command.AddParameter("ia", p.Admin);

            p.Id = (int)connection.ExecuteScalar(command);

            return p;
        }

        public bool Update(Projet p) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Projet SET Nom_Projet = @np, Description = @d, Date_Debut = @dd, Date_Fin = @df, Id_Admin = @ia WHERE Id_Projet = @id;");
            command.AddParameter("np", p.Nom);
            command.AddParameter("d", p.Description);
            command.AddParameter("dd", p.Debut);
            command.AddParameter("df", p.Fin);
            command.AddParameter("ia", p.Admin);
            command.AddParameter("id", p.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Projet WHERE Id_Projet = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
