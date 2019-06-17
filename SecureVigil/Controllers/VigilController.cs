using System.Threading.Tasks;
using System.Security.Claims;
using SecureVigil.DAL;
using SecureVigil.WebApp.Authentication;
using SecureVigil.WebApp.Models.VigilViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
namespace SecureVigil.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]

    public class VigilController : Controller
    {
        readonly VigilGeteway _vigilGeteway;
        
        public VigilController( VigilGeteway vigilGeteway )
        {
            _vigilGeteway = vigilGeteway;
        }

        [HttpGet]
        public async Task<IActionResult> GetVigilList()
        {
            IEnumerable<VigilData> result = await _vigilGeteway.GetAll();
            return Ok( result );
        }

        [HttpPost]
        public async Task<IActionResult> CreateVigil( [FromBody] VigilViewModel model )
        {
            Result<int> result = await _vigilGeteway.Create( model.FirstName, model.LastName,
                model.Phone, model.Adresse );
            return Ok( result.Content );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateVigil( int id, [FromBody] VigilViewModel model )
        {

            Result result = await _vigilGeteway.Update( model.VigilId, model.FirstName, model.LastName,
                model.Phone, model.Adresse );
            return this.CreateResult( result );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteVigil( int id )
        {
            Result result = await _vigilGeteway.Delete( id );
            return this.CreateResult( result );
        }
    }
}
