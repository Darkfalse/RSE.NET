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
    public class MessageEmployeeService {

        private DS.MessageEmployeeService service;

        public MessageEmployeeService() {
            service = new DS.MessageEmployeeService();
        }

        public IEnumerable<MessageEmployee> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public IEnumerable<MessageEmployee> GetByDestinataire(int id) {
            return service.GetByDestinataire(id).Select(a => a.ToClient());
        }

        public IEnumerable<MessageEmployee> GetDiscution(int idenv, int iddest) {
            return service.GetDiscution(idenv, iddest).Select(a => a.ToClient());
        }

        public MessageEmployee GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public MessageEmployee Insert(MessageEmployee me) {
            return service.Insert(me.ToDal()).ToClient();
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
