using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SecureVigil.WebApp.Models.ClientsViewModels
{
    public class ContratViewModels
    {
        [Required]
        [Display (Name = "Client")]
        public int ClientId { get; set; }

        [Required]
        [Display (Name = "Begin Date")]
        public DateTime BeginDate { get; set; }

        [Required]
        [Display (Name = "End Date")]
        public DateTime EndDate { get; set; }


    }
}
