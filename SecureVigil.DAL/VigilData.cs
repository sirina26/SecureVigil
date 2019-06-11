using System;
using System.Collections.Generic;
using System.Text;

namespace SecureVigil.DAL
{
    public class VigilData
    {
        public int VigilId { get; set; }

        public string FistName { get; set; }

        public string LastNAme { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime TallyBegin { get; set; }

        public DateTime TallyEnd { get; set; }
    }
}
