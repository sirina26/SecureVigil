using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using SecureVigil.DAL;
using SecureVigil.WebApp.Authentication;
using SecureVigil.WebApp.Models.ClientViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace SecureVigil.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]

    public class ClientController
    {

    }
}
