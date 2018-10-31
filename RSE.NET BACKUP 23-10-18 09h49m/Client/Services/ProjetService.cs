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
    public class ProjetService {

        private DS.ProjetService service;

        public ProjetService() {
            service = new DS.ProjetService();
        }

        public IEnumerable<Projet> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public IEnumerable<Projet> GetListByIdEmpl(int id) {
            return service.GetListByIdEmpl(id).Select(a => a.ToClient());
        }

        public Projet GetByIdEmpl(int id) {
            return service.GetByIdEmpl(id).ToClient();
        }

        public Projet GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public Projet Insert(Projet p) {
            return service.Insert(p.ToDal()).ToClient();
        }

        public bool Update(Projet p) {
            return service.Update(p.ToDal());
        }
    }
}
