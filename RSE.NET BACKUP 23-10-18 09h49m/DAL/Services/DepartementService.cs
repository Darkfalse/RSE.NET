using DAL.Models;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL.Services {
    class DepartementService {

        private readonly string providerName = ConfigurationManager.ConnectionStrings["SQLConnection"].ProviderName;
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
        //TODO DepartementService
    }
}
