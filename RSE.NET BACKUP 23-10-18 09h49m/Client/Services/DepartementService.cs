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
    public class DepartementService {

        private DS.DepartementService service;

        public DepartementService() {
            service = new DS.DepartementService();
        }

        public IEnumerable<Departement> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public Departement GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public Departement Insert(Departement a) {
            return service.Insert(a.ToDal()).ToClient();
        }

        public bool AffecteEmployee(int idEmp, int idDep) {
            return service.AffecteEmployee(idEmp, idDep);
        }

        public bool Update(Departement a) {
            return service.Update(a.ToDal());
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
