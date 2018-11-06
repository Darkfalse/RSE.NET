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
    public class MessageTacheService {

        private readonly string providerName = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<MessageTache> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Tache;");

            return connection.ExecuteReader(command, (dr) => dr.ToMessageTache());
        }

        public IEnumerable<MessageTache> GetByTacheId(int id)
        {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_MsgTacheByTache @id = @i;");
            command.AddParameter("i", id);

            return  connection.ExecuteReader(command, (dr) => dr.ToMessageTache());
        }

        public IEnumerable<MessageTache> GetByTacheEmployeeId(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_MsgTacheByTacheEmployee @id = @i;");
            command.AddParameter("i", id);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageTache());
        }

        public IEnumerable<MessageTache> GetByTacheEquipeId(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_MsgTacheByTacheEquipe @id = @i;");
            command.AddParameter("i", id);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageTache());
        }

        public MessageTache GetById(int id)
        {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Tache WHERE Id_Message_Tache = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageTache()).SingleOrDefault();
        }

        public MessageTache Insert(MessageTache mt) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("EXEC SP_InsertMsgTache @titre = @ti, @date = @da, @texte = @txt, @idmsg = @im, @idemp = @ie, @idtq = @idtaq, @idte = @idtea;");
            command.AddParameter("ti", mt.Titre);
            command.AddParameter("da", mt.Date);
            command.AddParameter("txt", mt.Contenu);
            command.AddParameter("im", mt.MessagePrecedent);
            command.AddParameter("idtaq", mt.Id_Tache_Equipe);
            command.AddParameter("idtea", mt.Id_Tache_Employee);
            command.AddParameter("ie", mt.Id_Employee);

            mt.Id = (int)connection.ExecuteScalar(command);

            return mt;
        }

        public bool Update(MessageTache mt) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Message_Tache SET Titre_Message = @tim, Date_Message = @dm, Texte_Message = @tm, Id_Message = @im, Id_Tache_Equipe = @ite, Id_Tache_Employee = @itemp, Id_Employee = @ie WHERE Id_Message_Tache = @id;");
            command.AddParameter("tim", mt.Titre);
            command.AddParameter("dm", mt.Date);
            command.AddParameter("tm", mt.Contenu);
            command.AddParameter("im", mt.MessagePrecedent);
            command.AddParameter("ite", mt.Id_Tache_Equipe);
            command.AddParameter("itemp", mt.Id_Tache_Employee);
            command.AddParameter("ie", mt.Id_Employee);
            command.AddParameter("id", mt.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Message_Tache WHERE Id_Message_Tache = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }

       
    }
}
