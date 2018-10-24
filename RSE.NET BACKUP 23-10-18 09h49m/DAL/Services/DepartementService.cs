using DAL.Models;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ToolBox;

namespace DAL.Services {
    class DepartementService {

        private readonly string providerName = ConfigurationManager.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<Departement> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Departement;");

            return connection.ExecuteReader(command, (dr) => dr.ToDepartement());
        }

        public Departement GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Departement WHERE Id_Departement = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToDepartement()).SingleOrDefault();
        }

        public Departement Insert(Departement d) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Departement (Nom_Departement, Description, Id_Admin) OUTPUT INSERTED.ID VALUES (@nd, @d, @ia);");
            command.AddParameter("nd", d.Nom);
            command.AddParameter("d", d.Description);
            command.AddParameter("ia", d.Admin);

            d.Id = (int)connection.ExecuteScalar(command);

            return d;
        }

        public bool Update(Departement d) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Departement SET Nom_Departement = @nd, Description = @d, Id_Admin = @ia WHERE Id_Departement = @id;");
            command.AddParameter("nd", d.Nom);
            command.AddParameter("d", d.Description);
            command.AddParameter("ia", d.Admin);
            command.AddParameter("id", d.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Departement WHERE Id_Departement = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
