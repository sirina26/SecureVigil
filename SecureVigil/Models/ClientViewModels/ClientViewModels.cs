using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SecureVigil.WebApp.Models.ClientViewModels
{
    public class ClientViewModels
    {
        public int ClientId { get; set; }

        public string FirstName{ get; set; }

        public string LastName { get; set; }

        public string ClientPhone { get; set; }

        public string ClientAdresse { get; set; }

    }
}
