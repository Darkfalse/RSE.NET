using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace DAL.Services {
    class EquipeService {

        private readonly string providerName = "System.Data.SqlClient";
        private readonly string connString = @"Data Source = FORMAVDI1605\TFTIC; Initial Catalog = RSE; User ID = sa; Password = tftic@2012;";

        public IEnumerable<Equipe> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Equipe;");

            return connection.ExecuteReader(command, (dr) => dr.ToEquipe());
        }

        public Equipe GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Equipe WHERE Id_Equipe = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToEquipe()).SingleOrDefault;
        }

        public Equipe Insert(Equipe e) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Equipe (Nom_Equipe, Date_Creation_Equipe, Id_Projet) OUTPUT INSERTED.ID VALUES (@ne, @d, @ip);");
            command.AddParameter("ne", e.Nom);
            command.AddParameter("d", e.Creee);
            command.AddParameter("ip", e.Projet);

            e.Id = (int)connection.ExecuteScalar(command);

            return e;
        }

        public bool Update(Equipe e) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Equipe SET Nom_Equipe = @ne, Date_Creation_Equipe = @d, Id_Projet = @ip WHERE Id_Equipe = @id;");
            command.AddParameter("ne", e.Nom);
            command.AddParameter("d", e.Creee);
            command.AddParameter("ip", e.Projet);
            command.AddParameter("id", e.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Equipe WHERE Id_Equipe = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
