using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SecureVigil.WebApp.Models.ClientViewModels
{
    public class ContratViewModel
    {
        public int ClientId { get; set; }

        public int ContratId { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
