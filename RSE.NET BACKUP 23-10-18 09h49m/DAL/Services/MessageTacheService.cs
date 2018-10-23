﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace DAL.Services {
    class MessageTacheService {

        private readonly string providerName = "System.Data.SqlClient";
        private readonly string connString = @"Data Source = FORMAVDI1605\TFTIC; Initial Catalog = RSE; User ID = sa; Password = tftic@2012;";

        public IEnumerable<MessageTache> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Tache;");

            return connection.ExecuteReader(command, (dr) => dr.ToMessageTache());
        }

        public MessageTache GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Tache WHERE Id_Message_Tache = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToMessageTache()).SingleOrDefault;
        }

        public MessageTache Insert(MessageTache mt) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Message_Tache (Titre_Message, Date_Message, Texte_Message, Id_Message, Id_Tache_Equipe, Id_Tache_Employee, Id_Employee) OUTPUT INSERTED.ID VALUES (@tim, @dm, @tm, @im, @ite, @itemp, @ie);");
            command.AddParameter("tim", mt.Titre);
            command.AddParameter("dm", mt.Date);
            command.AddParameter("tm", mt.Contenu);
            command.AddParameter("im", mt.MessagePrecedent);
            command.AddParameter("ite", mt.Id_Tache_Equipe);
            command.AddParameter("itemp", mt.Id_Tache_Emplopyee);
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
            command.AddParameter("itemp", mt.Id_Tache_Emplopyee);
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
