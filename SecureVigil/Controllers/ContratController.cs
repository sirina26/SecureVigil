using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureVigil.DAL;
using SecureVigil.WebApp.Authentication;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SecureVigil.WebApp.Models.ContratViewModel;
using System.Collections.Generic;

namespace SecureVigil.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]

    public class ContratController : Controller
    {
        readonly ContratGateway _contratGateway;

        public ContratController( ContratGateway contratGateway ) => _contratGateway = contratGateway;

        [HttpGet]
        public async Task<IActionResult> GetContratList()
        {
            IEnumerable<ContratData> result = await _contratGateway.GetAll();
            return Ok( result );
        }

        [HttpPost]
        public async Task<IActionResult> CreateContrat( [FromBody] ContratViewModel model )
        {
            int userId = int.Parse( User.Claims.ElementAt<Claim>( 0 ).Value );
            Result<int> result = await _contratGateway.Create(model.ClientId, model.BeginDate,
                model.EndDate );
            return Ok( result.Content );

        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateContrat( int id, [FromBody] ContratViewModel model )
        {

            Result result = await _contratGateway.Update( model.ContratId, model.ClientId, model.BeginDate,
                model.EndDate );
            return this.CreateResult( result );
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll( )
        {
           IEnumerable<ContratData> result = await _contratGateway.GetAll();
            return Ok( result );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteContrat( int id )
        {
            Result result = await _contratGateway.Delete( id );
            return this.CreateResult( result );
        }

    }
}
