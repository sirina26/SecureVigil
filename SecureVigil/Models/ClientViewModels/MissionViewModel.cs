using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SecureVigil.WebApp.Models.ClientViewModels
{
    public class MissionViewModels
    {
        public int MissionId { get; set; }

        public int ZoneId { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string MissionRules { get; set; }
    }
}
