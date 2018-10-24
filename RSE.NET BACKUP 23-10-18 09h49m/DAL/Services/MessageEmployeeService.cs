﻿using DAL.Models;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using System.Configuration;

namespace DAL.Services {
    class MessageEmployeeService {

        private readonly string providerName = ConfigurationManager.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<MessageEmployee> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Message_Employee;");

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
            Command command = new Command("INSERT INTO Message_Employee (Titre_Message, Date_Message, Texte_Message, Id_Message, Id_Employee_Destinataire, Id_Employee) OUTPUT INSERTED.ID VALUES (@tim, @dm, @tm, @im, @idd, @ie);");
            command.AddParameter("tim", me.Titre);
            command.AddParameter("dm", me.Date);
            command.AddParameter("tm", me.Contenu);
            command.AddParameter("im", me.MessagePrecedent);
            command.AddParameter("idd", me.Id_Destinataire);
            command.AddParameter("ie", me.Id_Employee);

            me.Id = (int)connection.ExecuteScalar(command);

            return me;
        }

        public bool Update(MessageEmployee me) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Message_Employee SET Titre_Message = @tim, Date_Message = @dm, Texte_Message = @tm, Id_Message = @im, Id_Employee_Destinataire = @idd, Id_Employee = @ie WHERE Id_Message_Employee = @id;");
            command.AddParameter("tim", me.Titre);
            command.AddParameter("dm", me.Date);
            command.AddParameter("tm", me.Contenu);
            command.AddParameter("im", me.MessagePrecedent);
            command.AddParameter("idd", me.Id_Destinataire);
            command.AddParameter("ie", me.Id_Employee);
            command.AddParameter("id", me.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Message_Employee WHERE Id_Message_Employee = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}