using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace DAL.Services {
    class EmployeeService {

        private readonly string providerName = "System.Data.SqlClient";
        private readonly string connString = @"Data Source = FORMAVDI1605\TFTIC; Initial Catalog = RSE; User ID = sa; Password = tftic@2012;";

        public IEnumerable<Employee> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Employee WHERE Actif = 1;");

            return connection.ExecuteReader(command, (dr) => dr.ToEmployee());
        }

        public Employee GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Employee WHERE Id_Equipe = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToEmployee()).SingleOrDefault;
        }

        public Employee Insert(Employee e) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Employee (Nom_Employee, Prenom, Email, Password, Birthday, RegNat, Id_Adresse, HireDate, Tel, Id_Coordonee) OUTPUT INSERTED.ID VALUES (@ne, @pr, @em, @pa, @bd, @rn, @ia, @hd, @te, @ic);");
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
            Command command = new Command("UPDATE Employee SET Nom_Employee = @ne, Prenom = @pr, Email = @em, Password = @pa, Birthday = @bd, RegNat = @rn, Id_Adresse = @ia, HireDate = @hd, Tel = @te, Id_Coordonee = @ic WHERE Id_Employee = @id;");
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
            command.AddParameter("id", e.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Employee WHERE Id_Employee = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
