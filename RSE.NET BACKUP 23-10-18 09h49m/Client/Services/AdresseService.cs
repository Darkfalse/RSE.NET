using Client.Mappers;
using Client.Models;
using DS = DAL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Client.Services {
    public class AdresseService {

        private DS.AdresseService service;

        public AdresseService() {
            service = new DS.AdresseService();
        }

        public IEnumerable<Adresse> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public Adresse GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public Adresse Insert(Adresse a) {
            return service.Insert(a.ToDal()).ToClient();
        }

        public bool Update(Adresse a) {
            return service.Update(a.ToDal());
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
