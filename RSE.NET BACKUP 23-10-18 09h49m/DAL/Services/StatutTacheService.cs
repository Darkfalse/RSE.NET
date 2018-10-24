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
    class StatutTacheService {

        private readonly string providerName = ConfigurationManager.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<StatutTache> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Statut_Tache;");

            return connection.ExecuteReader(command, (dr) => dr.ToStatutTache());
        }

        public StatutTache GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Statut_Tache WHERE Id_Statut_Tache = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToStatutTache()).SingleOrDefault();
        }
    }
}
