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
    public class MessageEmployeeService {

        private readonly string providerName = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<MessageEmployee> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Employee;");

            return connection.ExecuteReader(command, (dr) => dr.ToMessageEmployee());
        }

        public IEnumerable<MessageEmployee> GetByDestinataire(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Employee WHERE Id_Employee_Destinataire = @ied;");
            command.AddParameter("ied", id);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageEmployee());
        }

        public IEnumerable<MessageEmployee> GetDiscution(int idenv, int iddest) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_MsgEmployeeDiscution @idenv = @ie, @iddest = @id;");
            command.AddParameter("ie", idenv);
            command.AddParameter("id", iddest);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageEmployee());
        }

        public MessageEmployee GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Employee WHERE Id_Message_Employee = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageEmployee()).SingleOrDefault();
        }

        public MessageEmployee Insert(MessageEmployee me) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_InsertMsgEmployee @titre = @ti, @date = @da, @texte = @txt, @idmsg = @im, @idemp = @ie, @iddest = @id;");
            command.AddParameter("ti", me.Titre);
            command.AddParameter("da", me.Date);
            command.AddParameter("txt", me.Contenu);
            command.AddParameter("im", me.MessagePrecedent);
            command.AddParameter("ie", me.Id_Employee);
            command.AddParameter("id", me.Id_Destinataire);

            me.Id = (int)connection.ExecuteScalar(command);

            return me;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Message_Employee WHERE Id_Message_Employee = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
