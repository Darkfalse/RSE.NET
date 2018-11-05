using Client.Mappers;
using Client.Models;
using DS = DAL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services {
    public class AdministrateurService {

        private DS.AdministrateurService service;

        public AdministrateurService() {
            service = new DS.AdministrateurService();
        }

        public IEnumerable<Administrateur> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public Administrateur GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public Administrateur GetByIdEmployee(int id) {
            return service.GetByIdEmployee(id).ToClient();
        }

        public Administrateur Insert(Administrateur a) {
            return service.Insert(a.ToDal()).ToClient();
        }

        public bool Update(Administrateur a) {
            return service.Update(a.ToDal());
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
