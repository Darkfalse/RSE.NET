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
    public class TacheEquipeService {

        private readonly string providerName = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/_WebApp").ConnectionStrings.ConnectionStrings["SQLConnection"].ConnectionString;

        public IEnumerable<TacheEquipe> GetAll() {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Tache_Equipe;");

            return connection.ExecuteReader(command, (dr) => dr.ToTacheEquipe());
        }

        public TacheEquipe GetById(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("SELECT * FROM Tache_Equipe WHERE Id_Tache_Equipe = @Id;");
            command.AddParameter("Id", id);

            return connection.ExecuteReader(command, (dr) => dr.ToTacheEquipe()).SingleOrDefault();
        }

        public TacheEquipe Insert(TacheEquipe te) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("INSERT INTO Tache_Equipe (Nom_Tache, Description, Date_Debut, Date_Fin, Date_Final, Tache_Precedente, Id_Projet) OUTPUT INSERTED.ID VALUES (@nt, @d, @dd, @dfin, @dfinal, @tp, @ip);");
            command.AddParameter("nt", te.Nom);
            command.AddParameter("d", te.Description);
            command.AddParameter("dd", te.Debut);
            command.AddParameter("dfin", te.Fin);
            command.AddParameter("dfinal", te.Final);
            command.AddParameter("tp", te.TachePrecedente);
            command.AddParameter("ip", te.Projet);

            te.Id = (int)connection.ExecuteScalar(command);

            return te;
        }

        public bool Update(TacheEquipe te) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("UPDATE Tache_Equipe SET Nom_Tache = @nt, Description = @d, Date_Debut = @dd, Date_Fin = @dfin, Date_Final = @dfinal, Tache_Precedente = @tp, Id_Projet = @ip WHERE Id_Tache_Equipe = @id;");
            command.AddParameter("nt", te.Nom);
            command.AddParameter("d", te.Description);
            command.AddParameter("dd", te.Debut);
            command.AddParameter("dfin", te.Fin);
            command.AddParameter("dfinal", te.Final);
            command.AddParameter("tp", te.TachePrecedente);
            command.AddParameter("ip", te.Projet);
            command.AddParameter("id", te.Id);

            return connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id) {
            Connection connection = new Connection(providerName, connString);
            Command command = new Command("DELETE FROM Tache_Equipe WHERE Id_Tache_Equipe = @id;");
            command.AddParameter("id", id);

            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
