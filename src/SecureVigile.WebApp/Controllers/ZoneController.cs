using Microsoft.AspNetCore.Mvc;
using SecureVigile.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVigile.WebApp.Controllers
{
    [Route( "/api/[controller]" )]
    public class ZoneController : Controller
    {
        readonly ZoneGateway _zoneGateway;

        public ZoneController( ZoneGateway zoneGateway )
        {
            if( zoneGateway == null ) throw new ArgumentNullException( nameof( zoneGateway ) );
            _zoneGateway = zoneGateway;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ZoneData> zones = await _zoneGateway.GetAll();
            return Ok( zones );
        }
    }
}
