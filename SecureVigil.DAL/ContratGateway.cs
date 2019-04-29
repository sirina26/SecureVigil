using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SecureVigil.DAL
{
    public class ContratGateway
    {
        readonly string _connectionString;

        public ContratGateway( string connectionString )
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ContratData>> GetAll()
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QueryAsync<ContratData>( "Select * from securevigil.vContrat" );
            }
        }

        public async Task<Result<int>> Create(int clientId, DateTime beginDate, DateTime endDate )
        { 
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var c = new DynamicParameters();
                c.Add( "@ClientId", clientId );
                c.Add( "@BeginDate", beginDate );
                c.Add( "@EndDate", endDate );
                c.Add( "@ContratId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                c.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sContratCreate", c, commandType: CommandType.StoredProcedure );

                int status = c.Get<int>( "@Status" );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Created, c.Get<int>( "@ContratId" ) );
            }
        }

        public async Task<Result> Delete( int contratId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var m = new DynamicParameters();
                m.Add( "@ContratId", contratId );
                m.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sContratDelete", m, commandType: CommandType.StoredProcedure );

                int status = m.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Contrat not found." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result> Update( int contratId, int clientId, DateTime beginDate, DateTime endDate )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var m = new DynamicParameters();
                m.Add( "@ContratId", contratId );
                m.Add( "@ClientId", clientId );
                m.Add( "@BeginDate", beginDate );
                m.Add( "@EndDate", endDate );
                m.Add( "@status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sContratUpdate", m, commandType: CommandType.StoredProcedure );

                int status = m.Get<int>( "@status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Contrat not found." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Ok );
            }
        }
    }
}
