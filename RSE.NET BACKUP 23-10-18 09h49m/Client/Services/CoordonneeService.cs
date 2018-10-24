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
    public class CoordonneeService {

        private DS.CoordonneeService service;

        public CoordonneeService() {
            service = new DS.CoordonneeService();
        }

        public IEnumerable<Coordonnee> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public Coordonnee GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public Coordonnee Insert(Coordonnee a) {
            return service.Insert(a.ToDal()).ToClient();
        }

        public bool Update(Coordonnee a) {
            return service.Update(a.ToDal());
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
