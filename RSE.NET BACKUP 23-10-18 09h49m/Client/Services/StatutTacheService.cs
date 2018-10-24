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
    public class StatutTacheService {

        private DS.StatutTacheService service;

        public StatutTacheService() {
            service = new DS.StatutTacheService();
        }

        public IEnumerable<StatutTache> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public StatutTache GetById(int id) {
            return service.GetById(id).ToClient();
        }
    }
}
