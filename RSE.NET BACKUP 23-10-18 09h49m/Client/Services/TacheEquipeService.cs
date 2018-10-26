using Client.Mappers;
using Client.Models;
using DS = DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace Client.Services {
    public class TacheEquipeService {

        private DS.TacheEquipeService service;

        public TacheEquipeService() {
            service = new DS.TacheEquipeService();
        }

        public IEnumerable<TacheEquipe> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public IEnumerable<TacheEquipe> GetByProjet(int id) {
            return service.GetByProjet(id).Select(a => a.ToClient());
        }

        public TacheEquipe GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public TacheEquipe Insert(TacheEquipe p) {
            return service.Insert(p.ToDal()).ToClient();
        }

        public bool Update(TacheEquipe p) {
            return service.Update(p.ToDal());
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
