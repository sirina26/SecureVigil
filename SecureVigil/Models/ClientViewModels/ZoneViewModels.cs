using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SecureVigil.WebApp.Models.ClientViewModels
{
    public class ZoneViewModels
    {
        [Required]
        [Display (Name = "Zone Name")]
        public string ZoneName { get; set; }

        [Required]
        [Display (Name = "Zone Adresse")]
        public string ZoneAdresse { get; set; }

        [Display (Name ="Longitude")]
        public double Longitude { get; set; }

        [Display (Name ="Latitude")]
        public double Latitude { get; set; }

        [Required]
        [Display (Name = "Contrat")]
        public int ContratId { get; set; }

    }
}
