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

    public class ClientController: Controller
    {
        readonly ClientGateway _clientGateway;

        public ClientController( ClientGateway eventGateway )
        {
            _clientGateway = eventGateway;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventList()
        {
            IEnumerable<ClientData> result = await _clientGateway.GetAll();
            return Ok( result );
        }

        [HttpGet( "{id}", Name = "GetEvent" )]
        public async Task<IActionResult> GetEventById( int id )
        {
            Result<ClientData> result = await _clientGateway.FindById( id );
            return this.CreateResult( result );
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent( [FromBody] EventViewModel model )
        {
            int userId = int.Parse( User.Claims.ElementAt<Claim>( 0 ).Value );
            Result<int> result = await _clientGateway.Create( userId, model.EventName,
                model.Place, model.WeddingDate, model.MaximumPrice,
            model.NumberOfGuestes, model.Note );
            return this.CreateResult( result, o =>
            {
                o.RouteName = "GetEvent";
                o.RouteValues = id => new { id };
            } );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateEvent( int id, [FromBody] EventViewModel model )
        {

            Result result = await _clientGateway.Update( id, model.EventName,
                model.Place, model.WeddingDate, model.MaximumPrice,
           model.NumberOfGuestes, model.Note );//, model.CustomerId, model.OrganizerId );
            return this.CreateResult( result );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteEvent( int id )
        {
            Result result = await _clientGateway.Delete( id );
            return this.CreateResult( result );
        }
    }
}
