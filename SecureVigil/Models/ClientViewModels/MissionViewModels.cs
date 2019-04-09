using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SecureVigil.WebApp.Models.ClientViewModels
{
    public class MissionViewModels
    {
        [Required]
        [Display (Name = "Zone")]
        public int ZoneId { get; set; }

        [Required]
        [Display (Name = "Begin Date")]
        public DateTime BeginDate { get; set; }

        [Required]
        [Display (Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display (Name = "Mission Rules")]
        public string MissionRules { get; set; }
    }
}
