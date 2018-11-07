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
    public class MessageProjetService {

        private readonly string providerName = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<MessageProjet> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Projet;");

            return connection.ExecuteReader(command, (dr) => dr.ToMessageProjet());
        }

        public IEnumerable<MessageProjet> GetByProjet(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_MsgProjetByProjet @id = @i;");
            command.AddParameter("i", id);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageProjet());
        }

        public IEnumerable<MessageProjet> GetSujetByProjet(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_SujetByProjet @id = @i;");
            command.AddParameter("i", id);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageProjet());
        }        

        public MessageProjet GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Projet WHERE Id_Message_Projet = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageProjet()).SingleOrDefault();
        }

        public MessageProjet Insert(MessageProjet mp) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_InsertMsgProjet @titre = @ti, @date = @da, @texte = @txt, @idmsg = @im, @idemp = @ie, @idpro = @idp;");
            command.AddParameter("ti", mp.Titre);
            command.AddParameter("da", mp.Date);
            command.AddParameter("txt", mp.Contenu);
            command.AddParameter("im", mp.MessagePrecedent);
            command.AddParameter("idp", mp.Id_Projet);
            command.AddParameter("ie", mp.Id_Employee);

            mp.Id = (int)connection.ExecuteScalar(command);

            return mp;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Message_Projet WHERE Id_Message_Projet = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
