using DAL.Models;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
    class Test {
        public static void Main() {
            Employee e = new Employee {
                Id = 2,
                Nom = "Mertens",
                Prenom = "Nicolas",
                Email = "nicolas@hotmail.com",
                Password = "12345678",
                Birthday = new DateTime(1993, 12, 29),
                RegNat = "2912199346",
                Adresse = null,
                HireDate = new DateTime(2018, 10, 3),
                Tel = "0477354987",
                Coordonnee = null
            };

            EmployeeService es = new EmployeeService();
            //e = es.Insert(e);
            bool result = es.Update(e);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
