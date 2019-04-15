using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SecureVigil.WebApp.Models.ClientViewModels
{
    public class ZoneViewModels
    {
        public int ContratId { get; set; }

        public int ZoneId { get; set; }

        public string ZoneName { get; set; }

        public string ZoneAdresse { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }

    }
}
