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
    public class EventService {

        private readonly string providerName = ConfigurationManager.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<Event> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Event;");

            return connection.ExecuteReader(command, (dr) => dr.ToEvent());
        }

        public Event GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Event WHERE Id_Event = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToEvent()).SingleOrDefault();
        }

        public Event Insert(Event e) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Event (Nom_Event, Description, Lieu, Date_Debut, Date_Fin, FullDay, Id_Employee) OUTPUT INSERTED.ID VALUES (@ne, @d, @l, @dd, @df, @fd, @ie);");
            command.AddParameter("ne", e.Nom);
            command.AddParameter("d", e.Description);
            command.AddParameter("l", e.Lieu);
            command.AddParameter("dd", e.DateDebut);
            command.AddParameter("df", e.DateFin);
            command.AddParameter("fd", e.FullDay);
            command.AddParameter("ie", e.Id_Employee);

            e.Id = (int)connection.ExecuteScalar(command);

            return e;
        }

        public bool Update(Event e) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Event SET Nom_Event = @ne, Description = @d, Lieu = @l, Date_Debut = @dd, Date_Fin = @df, FullDay = @fd, Id_Employee = @ie WHERE Id_Event = @id;");
            command.AddParameter("ne", e.Nom);
            command.AddParameter("d", e.Description);
            command.AddParameter("l", e.Lieu);
            command.AddParameter("dd", e.DateDebut);
            command.AddParameter("df", e.DateFin);
            command.AddParameter("fd", e.FullDay);
            command.AddParameter("ie", e.Id_Employee);
            command.AddParameter("id", e.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Event WHERE Id_Event = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
