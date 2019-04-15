using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;


namespace SecureVigil.DAL
{
    public class ClientGateway
    {
        readonly string _connectionString;

        public ClientGateway( string connectionString )
        {
            _connectionString = connectionString;
        }

        
        public async Task<Result<ClientData>> FindById( int clientId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                ClientData eventi = await con.QueryFirstOrDefaultAsync<ClientData>(
                    @"select
                               s.FirstName,
                               s.LastName,
                               s.ClientPhone,
                               s.ClientAdresse

                      from securevigil.vClient s
                      where s.ClientId = @ClientId;",
                    new { ClientId = clientId } );

                if( eventi == null ) return Result.Failure<ClientData>( Status.NotFound, "Client not found." );
                return Result.Success( eventi );
            }
        }


        public async Task<Result<int>> Create( int clientId, string firstName, string lastName, string clientPhone, string clientAdresse)
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@clientId", clientId );
                p.Add( "@firstName", firstName );
                p.Add( "@lastName", lastName );
                p.Add( "@clientPhone", clientPhone );
                p.Add( "@clientAdresse", clientAdresse );
                p.Add( "@ClientId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sClientCreate", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Created, p.Get<int>( "@ClientId" ) );
            }
        }

        public async Task<Result> Delete( int eventId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@ClientId", eventId );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sClientDelete", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Client not found." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result> Update( int clientId, string firstName, string lastName, string clientPhone, string clientAdresse )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@clientId", clientId );
                p.Add( "@firstName", firstName );
                p.Add( "@lastName", lastName );
                p.Add( "@clientPhone", clientPhone );
                p.Add( "@clientAdresse", clientAdresse );
                p.Add( "@status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sClientUpdate", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Client not found." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Ok );
            }
        }
    }
}
