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
    public class MessageEquipeService {

        private readonly string providerName = ConfigurationManager.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<MessageEquipe> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Equipe;");

            return connection.ExecuteReader(command, (dr) => dr.ToMessageEquipe());
        }

        public MessageEquipe GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Equipe WHERE Id_Message_Equipe = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageEquipe()).SingleOrDefault();
        }

        public MessageEquipe Insert(MessageEquipe me) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Message_Equipe (Titre_Message, Date_Message, Texte_Message, Id_Message, Id_Equipe, Id_Employee) OUTPUT INSERTED.ID VALUES (@tim, @dm, @tm, @im, @ieq, @ie);");
            command.AddParameter("tim", me.Titre);
            command.AddParameter("dm", me.Date);
            command.AddParameter("tm", me.Contenu);
            command.AddParameter("im", me.MessagePrecedent);
            command.AddParameter("ieq", me.Id_Equipe);
            command.AddParameter("ie", me.Id_Employee);

            me.Id = (int)connection.ExecuteScalar(command);

            return me;
        }

        public bool Update(MessageEquipe me) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Message_Equipe SET Titre_Message = @tim, Date_Message = @dm, Texte_Message = @tm, Id_Message = @im, Id_Equipe = @ieq, Id_Employee = @ie WHERE Id_Message_Equipe = @id;");
            command.AddParameter("tim", me.Titre);
            command.AddParameter("dm", me.Date);
            command.AddParameter("tm", me.Contenu);
            command.AddParameter("im", me.MessagePrecedent);
            command.AddParameter("ieq", me.Id_Equipe);
            command.AddParameter("ie", me.Id_Employee);
            command.AddParameter("id", me.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Message_Equipe WHERE Id_Message_Equipe = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
