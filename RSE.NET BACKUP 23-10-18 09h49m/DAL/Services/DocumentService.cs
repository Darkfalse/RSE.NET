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
    class DocumentService {

        private readonly string providerName = ConfigurationManager.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<Document> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Document;");

            return connection.ExecuteReader(command, (dr) => dr.ToDocument());
        }

        public Document GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Document WHERE Id_Document = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToDocument()).SingleOrDefault();
        }

        public Document Insert(Document d) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Document (Nom_Document, Description, Date, Lien, Taille, Format, Id_Employee_Cree, Id_Employee_Maj) OUTPUT INSERTED.ID VALUES (@nd, @d, @da, @l, @t, @f, @ic, @im);");
            command.AddParameter("nd", d.Nom);
            command.AddParameter("d", d.Description);
            command.AddParameter("da", d.Date);
            command.AddParameter("l", d.Lien);
            command.AddParameter("t", d.Taille);
            command.AddParameter("f", d.Format);
            command.AddParameter("ic", d.Id_Emp_Creee);
            command.AddParameter("im", d.Id_Emp_Maj);

            d.Id = (int)connection.ExecuteScalar(command);

            return d;
        }

        public bool Update(Document d) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Equipe SET Nom_Document = @nd, Description = @d, Date = @da, Lien = @l, Taille = @t, Format = @f, Id_Employee_Cree = @ic, Id_Employee_Maj = @im WHERE Id_Document = @id;");
            command.AddParameter("nd", d.Nom);
            command.AddParameter("d", d.Description);
            command.AddParameter("da", d.Date);
            command.AddParameter("l", d.Lien);
            command.AddParameter("t", d.Taille);
            command.AddParameter("f", d.Format);
            command.AddParameter("ic", d.Id_Emp_Creee);
            command.AddParameter("im", d.Id_Emp_Maj);
            command.AddParameter("id", d.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Equipe WHERE Id_Document = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
