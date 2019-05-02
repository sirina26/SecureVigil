

using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SecureVigil.DAL
{
    public class ZoneGateway
    {
        readonly string _connectionString;

        public ZoneGateway( string connectionString )
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ZoneData>> GetAll()
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QueryAsync<ZoneData>( "Select * from securevigil.vZone" );
            }
        }

        public async Task<Result<int>> Create(int zoneId, int contratId, string zoneName, string zoneAdresse, float zoneLongitude, float zoneLatitude )
        {
            using (SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var z = new DynamicParameters();
                z.Add( "@ZoneId", zoneId );
                z.Add( "@ContratId", contratId );
                z.Add( "@ZoneName", zoneName );
                z.Add( "@ZoneAdresse", zoneAdresse );
                z.Add( "@Longitude", zoneLongitude );
                z.Add( "@Latitude", zoneLatitude );
                z.Add( "@ZoneId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                z.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sZoneCreate", z, commandType: CommandType.StoredProcedure );

                int status = z.Get<int>( "@Status" );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Created, z.Get<int>( "@ZoneId" ) );
            }
        }

        public async Task<Result> Delete(int zoneId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var z = new DynamicParameters();
                z.Add( "@ZoneId", zoneId );
                z.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sZoneDelete", z, commandType: CommandType.StoredProcedure );

                int status = z.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Zone not found." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result> Update(int zoneId, int contratId, string zoneName, string zoneAdresse, float zoneLongitude, float zoneLatitude )
        {
            using(SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var z = new DynamicParameters();
                z.Add( "@ZoneId", zoneId );
                z.Add( "@ContratId", contratId );
                z.Add( "@ZoneName", zoneName );
                z.Add( "@ZoneAdresse", zoneAdresse );
                z.Add( "@Longitude", zoneLongitude );
                z.Add( "@Latitude", zoneLatitude );
                z.Add( "@status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sZoneUpdate", z, commandType: CommandType.StoredProcedure );

                int status = z.Get<int>( "@status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Zone not found." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Ok );
            }
        }

        public async Task<IEnumerable<ZoneData>> GetZoneByContratId( int id )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QueryAsync<ZoneData>( "Select * from securevigil.vZone where ContratId = @Id", new { Id = id } );
            }
        }
    }
}
