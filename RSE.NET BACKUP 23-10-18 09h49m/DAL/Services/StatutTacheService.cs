using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace DAL.Services {
    class StatutTacheService {

        private readonly string providerName = "System.Data.SqlClient";
        private readonly string connString = @"Data Source = FORMAVDI1605\TFTIC; Initial Catalog = RSE; User ID = sa; Password = tftic@2012;";

        public IEnumerable<StatutTache> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Statut_Tache;");

            return connection.ExecuteReader(command, (dr) => dr.ToStatutTache());
        }

        public StatutTache GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Statut_Tache WHERE Id_Statut_Tache = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToStatutTache()).SingleOrDefault;
        }
    }
}
