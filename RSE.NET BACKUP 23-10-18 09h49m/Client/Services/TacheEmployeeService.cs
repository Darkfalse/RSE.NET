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
    public class TacheEmployeeService {

        private DS.TacheEmployeeService service;

        public TacheEmployeeService() {
            service = new DS.TacheEmployeeService();
        }

        public IEnumerable<TacheEmployee> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public IEnumerable<TacheEmployee> GetByEmployee(int id) {
            return service.GetByEmployee(id).Select(a => a.ToClient());
        }

        public TacheEmployee GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public TacheEmployee Insert(TacheEmployee p) {
            return service.Insert(p.ToDal()).ToClient();
        }

        public bool Update(TacheEmployee p) {
            return service.Update(p.ToDal());
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
