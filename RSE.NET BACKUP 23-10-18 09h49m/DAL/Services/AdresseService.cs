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
    public class AdresseService {

        private readonly string providerName = ConfigurationManager.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<Adresse> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Adresse;");

            return connection.ExecuteReader(command, (dr) => dr.ToAdresse());
        }

        public Adresse GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Adresse WHERE Id_Adresse = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToAdresse()).SingleOrDefault();
        }

        public Adresse Insert(Adresse a) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Adresse (Nom_Rue, Boite_Postal, Id_Ville) OUTPUT INSERTED.ID VALUES (@nr, @bp, @iv);");
            command.AddParameter("nr", a.Nom_Rue);
            command.AddParameter("bp", a.Boite_Postal);
            command.AddParameter("iv", a.Id_Ville);

            a.Id = (int)connection.ExecuteScalar(command);

            return a;
        }

        public bool Update(Adresse a) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Adresse SET Nom_Rue = @nr, Boite_Postal = @bp, Id_Ville = @iv WHERE Id_Adresse = @id;");
            command.AddParameter("nr", a.Nom_Rue);
            command.AddParameter("bp", a.Boite_Postal);
            command.AddParameter("iv", a.Id_Ville);
            command.AddParameter("id", a.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Adresse WHERE Id_Adresse = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
