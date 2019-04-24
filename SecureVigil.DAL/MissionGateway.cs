

using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SecureVigil.DAL
{
    public class MissionGateway
    {
        readonly string _connectionString;

        public MissionGateway( string connectionString )
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<MissionData>> GetAll()
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QueryAsync<MissionData>( "Select * from securevigil.vMission" );
            }
        }

        public async Task<Result<int>> Create( int missionId, int zoneId, DateTime beginDate, DateTime endDate, string missionRules )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var m = new DynamicParameters();
                m.Add( "@MissionId", missionId );
                m.Add( "@ZoneId", zoneId );
                m.Add( "@BeginDate", beginDate );
                m.Add( "@EndDate", endDate );
                m.Add( "@Missionrules", missionRules );
                m.Add( "@MissionId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                m.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sMissionCreate", m, commandType: CommandType.StoredProcedure );

                int status = m.Get<int>( "@Status" );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Created, m.Get<int>( "@MissionId" ) );
            }
        }

        public async Task<Result> Delete( int zoneId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var m = new DynamicParameters();
                m.Add( "@MissionId", zoneId );
                m.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sMissionDelete", m, commandType: CommandType.StoredProcedure );

                int status = m.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Mission not found." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result> Update( int missionId, int zoneId, DateTime beginDate, DateTime endDate, string missionRules )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var m = new DynamicParameters();
                m.Add( "@MissionId", missionId );
                m.Add( "@ZoneId", zoneId );
                m.Add( "@BeginDate", beginDate );
                m.Add( "@EndDate", endDate );
                m.Add( "@Missionrules", missionRules );
                m.Add( "@status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sMissionUpdate", m, commandType: CommandType.StoredProcedure );

                int status = m.Get<int>( "@status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Mission not found." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Ok );
            }
        }
    }
}
