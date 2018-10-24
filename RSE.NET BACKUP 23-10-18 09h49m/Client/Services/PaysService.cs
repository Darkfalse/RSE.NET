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
    public class PaysService {

        private DS.PaysService service;

        public PaysService() {
            service = new DS.PaysService();
        }

        public IEnumerable<Pays> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public Pays GetById(int id) {
            return service.GetById(id).ToClient();
        }
    }
}
