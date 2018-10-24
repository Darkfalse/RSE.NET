﻿using Client.Mappers;
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

        public Employee GetById(int id) {
            return service.GetById(id).ToClient();
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