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
    public class AdministrateurService {

        private readonly string providerName = ConfigurationManager.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<Administrateur> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Administrateur;");

            return connection.ExecuteReader(command, (dr) => dr.ToAdministrateur());
        }

        public Administrateur GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Administrateur WHERE Id_Admin = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToAdministrateur()).SingleOrDefault();
        }

        public Administrateur Insert(Administrateur a) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Administrateur (Numero_Admin, Id_Employee) OUTPUT INSERTED.ID VALUES (@na, @ie);");
            command.AddParameter("na", a.NumeroAdmin);
            command.AddParameter("ie", a.Employee);

            a.Id = (int)connection.ExecuteScalar(command);

            return a;
        }

        public bool Update(Administrateur a) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Administrateur SET Numero_Admin = @na, Id_Employee = @ie WHERE Id_Admin = @id;");
            command.AddParameter("na", a.NumeroAdmin);
            command.AddParameter("ie", a.Employee);
            command.AddParameter("id", a.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Administrateur WHERE Id_Admin = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
