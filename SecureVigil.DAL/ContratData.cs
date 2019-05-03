using System;

namespace SecureVigil.DAL
{
    public class ContratData
    {
        public int ClientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ContratId { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
