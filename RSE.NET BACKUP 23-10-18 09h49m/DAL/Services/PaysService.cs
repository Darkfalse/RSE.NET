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
    public class PaysService {

        private readonly string providerName = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<Pays> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Pays;");

            return connection.ExecuteReader(command, (dr) => dr.ToPays());
        }

        public Pays GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Pays WHERE Id_Pays = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToPays()).SingleOrDefault();
        }

        public Pays GetByName(string nomPays) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Pays WHERE Nom_Francais = @nf;");
            command.AddParameter("nf", nomPays);

            return connection.ExecuteReader(command, (dr) => dr.ToPays()).SingleOrDefault();
        }
    }
}
