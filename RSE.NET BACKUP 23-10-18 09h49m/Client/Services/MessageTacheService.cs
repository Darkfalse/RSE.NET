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
    public class MessageTacheService {

        private DS.MessageTacheService service;

        public MessageTacheService() {
            service = new DS.MessageTacheService();
        }

        public IEnumerable<MessageTache> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public MessageTache GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public MessageTache Insert(MessageTache mt) {
            return service.Insert(mt.ToDal()).ToClient();
        }

        public bool Update(MessageTache mt) {
            return service.Update(mt.ToDal());
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
