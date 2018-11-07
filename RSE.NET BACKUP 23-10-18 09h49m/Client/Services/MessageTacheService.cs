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

        public IEnumerable<MessageTache> GetByTacheId(int id)
        {
            return service.GetByTacheId(id).Select(a => a.ToClient());
        }

        public IEnumerable<MessageTache> GetSujetByTacheId(int id) {
            return service.GetSujetByTacheId(id).Select(a => a.ToClient());
        }

        public MessageTache GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public MessageTache Insert(MessageTache mt) {
            return service.Insert(mt.ToDal()).ToClient();
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
