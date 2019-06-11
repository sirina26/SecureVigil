using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SecureVigil.WebApp.Models.VigilViewModel
{
    public class VigilViewModel
    {
        public int VigilId { get; set; }

        public string FistName { get; set; }

        public string LastNAme { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}

