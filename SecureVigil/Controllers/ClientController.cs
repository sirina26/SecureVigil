using System.Threading.Tasks;
using System.Security.Claims;
using SecureVigil.DAL;
using SecureVigil.WebApp.Authentication;
using SecureVigil.WebApp.Models.ClientViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace SecureVigil.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]

    public class ClientController: Controller
    {
        readonly ClientGateway _clientGateway;

        public ClientController( ClientGateway clientGateway )
        {
            _clientGateway = clientGateway;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientList()
        {
            IEnumerable<ClientData> result = await _clientGateway.GetAll();
            return Ok( result );
        }

        //[HttpGet( "{id}", Name = "GetClient" )]
        //public async Task<IActionResult> GetClientById( int id )
        //{
        //    Result<ClientData> result = await _clientGateway.FindById( id );
        //    return this.CreateResult( result );
        //}

        [HttpPost]
        public async Task<IActionResult> CreateClient ( [FromBody] ClientViewModel model )
        {
            int userId = int.Parse( User.Claims.ElementAt<Claim>( 0 ).Value );
            Result<int> result = await _clientGateway.Create( model.FirstName, model.LastName,
                model.ClientPhone, model.ClientAdresse );
            return Ok( result.Content );
            //return this.CreateResult( result, o =>
            //{
            //    o.RouteName = "GetClient";
            //    o.RouteValues = id => new { id };
            //} );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateClient( int id, [FromBody] ClientViewModel model )
        {

            Result result = await _clientGateway.Update( model.ClientId, model.FirstName, model.LastName,
                model.ClientPhone, model.ClientAdresse );
            return this.CreateResult( result );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteClient( int id )
        {
            Result result = await _clientGateway.Delete( id );
            return this.CreateResult( result );
        }
    }
}
