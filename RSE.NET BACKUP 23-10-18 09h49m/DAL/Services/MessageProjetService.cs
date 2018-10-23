using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace DAL.Services {
    class MessageProjetService {

        private readonly string providerName = "System.Data.SqlClient";
        private readonly string connString = @"Data Source = FORMAVDI1605\TFTIC; Initial Catalog = RSE; User ID = sa; Password = tftic@2012;";

        public IEnumerable<MessageProjet> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Projet;");

            return connection.ExecuteReader(command, (dr) => dr.ToMessageProjet());
        }

        public MessageProjet GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Projet WHERE Id_Message_Projet = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageProjet()).SingleOrDefault;
        }

        public MessageProjet Insert(MessageProjet mp) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Message_Projet (Titre_Message, Date_Message, Texte_Message, Id_Message, Id_Projet, Id_Employee) OUTPUT INSERTED.ID VALUES (@tim, @dm, @tm, @im, @ip, @ie);");
            command.AddParameter("tim", mp.Titre);
            command.AddParameter("dm", mp.Date);
            command.AddParameter("tm", mp.Contenu);
            command.AddParameter("im", mp.MessagePrecedent);
            command.AddParameter("ip", mp.Id_Projet);
            command.AddParameter("ie", mp.Id_Employee);

            mp.Id = (int)connection.ExecuteScalar(command);

            return mp;
        }

        public bool Update(MessageProjet mp) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Message_Projet SET Titre_Message = @tim, Date_Message = @dm, Texte_Message = @tm, Id_Message = @im, Id_Projet, Id_Employee = @ie WHERE Id_Message_Tache = @id;");
            command.AddParameter("tim", mp.Titre);
            command.AddParameter("dm", mp.Date);
            command.AddParameter("tm", mp.Contenu);
            command.AddParameter("im", mp.MessagePrecedent);
            command.AddParameter("ip", mp.Id_Projet);
            command.AddParameter("ie", mp.Id_Employee);
            command.AddParameter("id", mp.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Message_Projet WHERE Id_Message_Projet = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
