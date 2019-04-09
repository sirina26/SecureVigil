using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SecureVigil.WebApp.Models.ClientViewModels
{
    public class ClientViewModels
    {
        [Required]
        [Display (Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display (Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display (Name = "Phone Number")]
        public string ClientPhone { get; set; }

        [Required]
        [Display (Name = "Client Adress")]
        public string ClientAdrsesse { get; set; }


    }
}
