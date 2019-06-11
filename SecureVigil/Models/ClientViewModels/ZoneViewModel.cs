using System;

namespace SecureVigil.WebApp.Models.ZoneViewModel
{
    public class ZoneViewModel
    {
        public int ContratId { get; set; }

        public int ZoneId { get; set; }

        public string ZoneName { get; set; }

        public string ZoneAdresse { get; set; }

        public int NbrAgentJour { get; set; }

        public int NbrAgentNuit { get; set; }

        public int NbrChienJour { get; set; }

        public int NbrChienNuit { get; set; }

    
    }
}
