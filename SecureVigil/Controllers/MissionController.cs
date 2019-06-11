using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureVigil.DAL;
using SecureVigil.WebApp.Authentication;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SecureVigil.WebApp.Models.MissionViewModel;
using System.Collections.Generic;

namespace SecureVigil.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]

    public class MissionController : Controller
    {
        readonly MissionGateway _missionGateway;

        public MissionController( MissionGateway missionGateway ) => _missionGateway = missionGateway;

        [HttpPost]
        public async Task<IActionResult> CreateMission( [FromBody] MissionViewModel model )
        {
            Result<int> result = await _missionGateway.Create( model.ZoneId, model.BeginDate,
                model.EndDate, model.MissionRules );
            return Ok( result.Content );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateMission( int id, [FromBody] MissionViewModel model )
        {

            Result result = await _missionGateway.Update( model.MissionId, model.ZoneId, model.BeginDate,
                model.EndDate, model.MissionRules );
            return this.CreateResult( result );
        }

        [HttpGet( "getAll" )]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<MissionData> result = await _missionGateway.GetAll();
            return Ok( result );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteMission( int id )
        {
            Result result = await _missionGateway.Delete( id );
            return this.CreateResult( result );
        }


        [HttpGet( "zone/{id}" )]
        public async Task<IActionResult> GetMissionByZoneID( int id )
        {
            IEnumerable<MissionData> result = await _missionGateway.GetMissionByZoneId( id );
            return Ok( result );
        }

        [HttpGet( "getMissionTree" )]
        public async Task<IActionResult> GetMissionTree()
        {
            string json = await _missionGateway.GetMissionTree();
            return Content( json, "application/json" );
        }

    }
}
