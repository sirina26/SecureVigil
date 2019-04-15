using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SecureVigile.DAL
{
    public class ZoneGateway
    {
        readonly IOptions<DbOptions> _options;

        public ZoneGateway( IOptions<DbOptions> options )
        {
            if( options == null ) throw new ArgumentNullException( nameof( options ) );
            _options = options;
        }

        public async Task<IEnumerable<ZoneData>> GetAll()
        {
            using( SqlConnection conn = new SqlConnection( _options.Value.ConnectionString ) )
            {
                return await conn.QueryAsync<ZoneData>( "select z.ZoneId, z.[Name] from sv.vZone z;" );
            }
        }
    }
}
