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
    public class DocumentService {

        private DS.DocumentService service;

        public DocumentService() {
            service = new DS.DocumentService();
        }

        public IEnumerable<Document> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public IEnumerable<Document> GetByProjet(int id) {
            return service.GetByProjet(id).Select(a => a.ToClient());
        }

        public Document GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public Document Insert(Document a) {
            return service.Insert(a.ToDal()).ToClient();
        }

        public bool Update(Document a) {
            return service.Update(a.ToDal());
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
