using System;

namespace SecureVigil
{
    public class MissionData
    {
        public int MissionId { get; set; }

        public int ZoneId { get; set; }

        public int VigilId { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string MissionRules { get; set; }
    }
}
