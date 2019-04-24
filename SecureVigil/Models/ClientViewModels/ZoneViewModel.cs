using System;

namespace SecureVigil.WebApp.Models.ZoneViewModel
{
    public class ZoneViewModel
    {
        public int ContratId { get; set; }

        public int ZoneId { get; set; }

        public string ZoneName { get; set; }

        public string ZoneAdresse { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }

    }
}
