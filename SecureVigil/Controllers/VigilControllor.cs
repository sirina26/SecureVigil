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

    public class VigilControllor : Controller
    {
        readonly VigilGeteway _vigilGeteway;
        
        public VigilControllor( VigilGeteway vigilGeteway )
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
            Result<int> result = await _vigilGeteway.Create( model.FistName, model.LastNAme,
                model.BeginDate, model.EndDate);
            return Ok( result.Content );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateVigil( int id, [FromBody] VigilViewModel model )
        {

            Result result = await _vigilGeteway.Update( model.VigilId, model.FistName, model.LastNAme,
                model.BeginDate, model.EndDate );
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
