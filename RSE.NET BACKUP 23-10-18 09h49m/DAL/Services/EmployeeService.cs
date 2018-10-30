using DAL.Models;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using System.Configuration;
using System.Data;

namespace DAL.Services {
    public class EmployeeService {

        private readonly string providerName = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<Employee> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Employee WHERE Actif = 1;");

            return connection.ExecuteReader(command, (dr) => dr.ToEmployee());
        }

        public IEnumerable<Employee> GetByEquipe(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_EmployeeByEquipe @id = @i;");
            command.AddParameter("i", id);

            return connection.ExecuteReader(command, (dr) => dr.ToEmployee());
        }

        public Employee GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Employee WHERE Id_Equipe = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToEmployee()).SingleOrDefault();
        }

        public Employee GetByEmailPassword(string email, string password) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_SelectEmployeeByEmailPassword @email = @em, @pass = @pa;");
            command.AddParameter("em", email);
            command.AddParameter("pa", password);

            //IEnumerable<IDataRecord> drs = connection.ExecuteReader(command, (dr) => dr);
            //if (drs != null && drs.SingleOrDefault() != null)
            //    return drs.SingleOrDefault().ToEmployee();
            //else
            //    return null;
            
            return connection.ExecuteReader(command, (dr) => dr.ToEmployee()).SingleOrDefault();
        }

        public Employee GetManagerByProjet(int idProjet) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_SelectManagerByProjet @id = @i;");
            command.AddParameter("i", idProjet);

            return connection.ExecuteReader(command, (dr) => dr.ToEmployee()).SingleOrDefault();
        }

        public Employee Insert(Employee e) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_AddEmployee @nom = @ne, @prenom = @pr, @email = @em, @password = @pa, @birtday = @bd, @regnat = @rn, @idadresse = @ia, @hiredate = @hd, @tel = @te, @idcoordonee = @ic;");
            command.AddParameter("ne", e.Nom);
            command.AddParameter("pr", e.Prenom);
            command.AddParameter("em", e.Email);
            command.AddParameter("pa", e.Password);
            command.AddParameter("bd", e.Birthday);
            command.AddParameter("rn", e.RegNat);
            command.AddParameter("ia", e.Adresse);
            command.AddParameter("hd", e.HireDate);
            command.AddParameter("te", e.Tel);
            command.AddParameter("ic", e.Coordonnee);


            e.Id = (int)connection.ExecuteScalar(command);

            return e;
        }

        public bool Update(Employee e) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_UpdateEmployee @id = @ide, @nom = @ne, @prenom = @pr, @email = @em, @password = @pa, @birtday = @bd, @regnat = @rn, @idadresse = @ia, @hiredate = @hd, @tel = @te, @idcoordonee = @ic;");
            command.AddParameter("ne", e.Nom);
            command.AddParameter("pr", e.Prenom);
            command.AddParameter("em", e.Email);
            command.AddParameter("pa", e.Password);
            command.AddParameter("bd", e.Birthday);
            command.AddParameter("rn", e.RegNat);
            command.AddParameter("ia", e.Adresse);
            command.AddParameter("hd", e.HireDate);
            command.AddParameter("te", e.Tel);
            command.AddParameter("ic", e.Coordonnee);
            command.AddParameter("ide", e.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool ValideEmployee(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_ValideEmployee @id = @i;");
            command.AddParameter("i", id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_DeleteEmployee @id = @ide;");
            command.AddParameter("ide", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
