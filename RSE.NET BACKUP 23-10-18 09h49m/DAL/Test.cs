using DAL.Models;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
    class Test {
        public void main() {
            Employee e = new Employee {
                Nom = "Mertens",
                Prenom = "Nicolas",
                Email = "nicolas@hotmail.com",
                Password = "12345678",
                Birthday = new DateTime(1993, 12, 29),
                RegNat = "1993122944587",
                Adresse = null,
                HireDate = new DateTime(2018, 10, 3),
                Tel = "0477354987",
                Coordonnee = null
            };

            EmployeeService es = new EmployeeService();
            e = es.Insert(e);

            Console.WriteLine(e.Id);
            Console.ReadLine();
        }
    }
}
