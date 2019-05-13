using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureVigil.DAL;
using SecureVigil.WebApp.Authentication;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SecureVigil.WebApp.Models.ZoneViewModel;
using System.Collections.Generic;

namespace SecureVigil.WebApp.Controllers
{
        [Route( "api/[controller]" )]
        [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]

    public class ZoneController : Controller
    {
        readonly ZoneGateway _zoneGateway;

        public ZoneController( ZoneGateway zoneGateway ) => _zoneGateway = zoneGateway;
        [HttpPost]
        public async Task<IActionResult> CreateZone ([FromBody] ZoneViewModel model)
        {
            int userId = int.Parse( User.Claims.ElementAt<Claim>( 0 ).Value );
            Result<int> result = await _zoneGateway.Create( model.ZoneId, model.ContratId, model.ZoneName,
                model.ZoneAdresse, model.GeogCol1 );
            return this.CreateResult( result, o =>
            {
                o.RouteName = "GetZone";
                o.RouteValues = id => new { id };
            } );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateZone( int id, [FromBody] ZoneViewModel model )
        {

            Result result = await _zoneGateway.Update( model.ZoneId, model.ContratId, model.ZoneName,
                model.ZoneAdresse, model.GeogCol1 );
            return this.CreateResult( result );
        }

        [HttpGet( "getAll" )]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ZoneData> result = await _zoneGateway.GetAll();
            return Ok( result );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteZone( int id )
        {
            Result result = await _zoneGateway.Delete( id );
            return this.CreateResult( result );
        }

    }
}
