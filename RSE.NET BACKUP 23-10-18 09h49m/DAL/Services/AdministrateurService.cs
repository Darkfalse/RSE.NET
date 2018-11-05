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

        private readonly string providerName = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<Administrateur> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Administrateur;");

            return connection.ExecuteReader(command, (dr) => dr.ToAdministrateur());
        }

        public Administrateur GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Administrateur WHERE Id_Admin = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToAdministrateur()).SingleOrDefault();
        }

        public Administrateur GetByIdEmployee(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Administrateur WHERE Id_Employee = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToAdministrateur()).SingleOrDefault();
        }

        public Administrateur Insert(Administrateur a) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_AddAdmin @num = @na, @idemp = @ie;");
            command.AddParameter("na", a.NumeroAdmin);
            command.AddParameter("ie", a.Employee);

            a.Id = (int)connection.ExecuteScalar(command);

            return a;
        }

        public bool Update(Administrateur a) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_UpdateAdmin @id = @i, @num = @na, @idemp = @ide;");
            command.AddParameter("na", a.NumeroAdmin);
            command.AddParameter("ide", a.Employee);
            command.AddParameter("i", a.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_DeleteAdmin @id = @ida;");
            command.AddParameter("ida", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
