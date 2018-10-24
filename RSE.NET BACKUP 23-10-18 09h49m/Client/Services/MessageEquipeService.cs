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
    public class MessageEquipeService {

        private DS.MessageEquipeService service;

        public MessageEquipeService() {
            service = new DS.MessageEquipeService();
        }

        public IEnumerable<MessageEquipe> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public MessageEquipe GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public MessageEquipe Insert(MessageEquipe me) {
            return service.Insert(me.ToDal()).ToClient();
        }

        public bool Update(MessageEquipe me) {
            return service.Update(me.ToDal());
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
