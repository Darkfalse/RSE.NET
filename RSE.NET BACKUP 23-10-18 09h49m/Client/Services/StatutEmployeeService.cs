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
    public class StatutEmployeeService {

        private DS.StatutEmployeeService service;

        public StatutEmployeeService() {
            service = new DS.StatutEmployeeService();
        }

        public IEnumerable<StatutEmployee> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public StatutEmployee GetById(int id) {
            return service.GetById(id).ToClient();
        }
    }
}
