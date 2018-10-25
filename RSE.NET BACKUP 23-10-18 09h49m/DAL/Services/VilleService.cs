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
    public class VilleService {

        private readonly string providerName = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<Ville> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Ville;");

            return connection.ExecuteReader(command, (dr) => dr.ToVille());
        }

        public Ville GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Ville WHERE Id_Ville = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToVille()).SingleOrDefault();
        }

        public Ville GetByNomZipPays(string nom, string zip, int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Ville WHERE Nom_Ville = @nv AND Zip = @zp AND Id_Pays = @id;");
            command.AddParameter("np", nom);
            command.AddParameter("zp", zip);
            command.AddParameter("id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToVille()).SingleOrDefault();
        }
    }
}
