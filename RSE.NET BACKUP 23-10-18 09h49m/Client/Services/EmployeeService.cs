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
    public class EmployeeService {

        private DS.EmployeeService service;

        public EmployeeService() {
            service = new DS.EmployeeService();
        }

        public IEnumerable<Employee> GetAll() {
            return service.GetAll().Select(a => a.ToClient());
        }

        public IEnumerable<Employee> GetByEquipe(int id) {
            return service.GetByEquipe(id).Select(a => a.ToClient());
        }

        public Employee GetById(int id) {
            return service.GetById(id).ToClient();
        }

        public Employee GetByEmailPassword(string email, string password) {
            return service.GetByEmailPassword(email, password).ToClient();
            //DAL.Models.Employee e = service.GetByEmailPassword(email, password);
            //if (e != null)
            //    return e.ToClient();
            //else
            //    return null;
        }

        public Employee GetManagerByProjet(int idProjet) {
            return service.GetManagerByProjet(idProjet).ToClient();
        }

        public Employee Insert(Employee a) {
            return service.Insert(a.ToDal()).ToClient();
        }

        public bool Update(Employee a) {
            return service.Update(a.ToDal());
        }

        public bool Delete(int id) {
            return service.Delete(id);
        }
    }
}
