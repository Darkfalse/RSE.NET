using DAL.Mappers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace DAL.Services {
    class CoordonneeService {

        private readonly string providerName = ConfigurationManager.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<Coordonnee> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Coordonnee;");

            return connection.ExecuteReader(command, (dr) => dr.ToCoordonnee());
        }

        public Coordonnee GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Coordonnee WHERE Id_Coordonnee = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToCoordonnee()).SingleOrDefault();
        }

        public Coordonnee Insert(Coordonnee c) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Coordonnee (Longitude, Latitude) OUTPUT INSERTED.ID VALUES (@lo, @la);");
            command.AddParameter("lo", c.Longitude);
            command.AddParameter("la", c.Latitude);

            c.Id = (int)connection.ExecuteScalar(command);

            return c;
        }

        public bool Update(Coordonnee c) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Coordonnee SET Longitude = @lo, Latitude = @la WHERE Id_Coordonnee = @id;");
            command.AddParameter("lo", c.Longitude);
            command.AddParameter("la", c.Latitude);
            command.AddParameter("id", c.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Coordonnee WHERE Id_Coordonnee = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
