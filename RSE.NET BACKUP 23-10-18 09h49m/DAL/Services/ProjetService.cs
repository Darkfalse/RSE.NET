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

        public IEnumerable<Projet> GetListByIdEmpl(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_ProjetDEmployee @id = @i;");
            command.AddParameter("i", id);

            return connection.ExecuteReader(command, (dr) => dr.ToProjet());
        }

        public IEnumerable<Projet> GetByIdEmpl(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_ProjetDEmployee @id = @i;");
            command.AddParameter("i", id);

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
            Command command = new Command("EXEC SP_AddProjet @nom = @np, @des = @d, @debut = @dd, @fin = @df, @idadmin = @ia;");
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
            Command command = new Command("EXEC SP_UpdateProjet @id = @i, @nom = @np, @des = @d, @fin = @df;");
            command.AddParameter("np", p.Nom);
            command.AddParameter("d", p.Description);
            command.AddParameter("df", p.Fin);
            command.AddParameter("i", p.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
