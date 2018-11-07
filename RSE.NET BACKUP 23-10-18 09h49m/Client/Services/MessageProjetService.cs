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
    public class MessageProjetService {

        private DS.MessageProjetService service;

        public MessageProjetService() {
            service = new DS.MessageProjetService();
        }

        public IEnumerable<MessageProjet> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public IEnumerable<MessageProjet> GetByProjet(int id) {
            return service.GetByProjet(id).Select(a => a.ToClient());
        }

        public MessageProjet GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public MessageProjet Insert(MessageProjet mp) {
            return service.Insert(mp.ToDal()).ToClient();
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
