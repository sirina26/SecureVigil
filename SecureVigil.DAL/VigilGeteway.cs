using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;

namespace SecureVigil.DAL
{
    public class VigilGeteway
    {
        readonly string _connectionString;

        public VigilGeteway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<VigilData>>GetAll()
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QueryAsync<VigilData>(
                    @"select

                        s.VigilId,
                        s.FirstName,
                        s.LastName,
                        s.Phone, 
                        s.Adresse
                    From securevigil.vVigil s" );
            }
        }

        public async Task<Result<int>> Create(string firstName, string LastName, string phone, string adresse )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@FirstName", firstName );
                p.Add( "@LastName", LastName );
                p.Add( "@Phone", phone );
                p.Add( "@Adresse", adresse  );
                p.Add( "@VigilId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "securevigil.sVigilCreate", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Created, p.Get<int>( "@VigilId" ) );
            }
        }

        public async Task<Result> Delete( int vigilId)
        {
            using( SqlConnection cnx = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@VigilId", vigilId );
                p.Add( "@Statue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await cnx.ExecuteAsync( "securevigil.sVigilDelete", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Vigil not found" );

                Debug.Assert( status == 0 );
                return Result.Success();
            }

        }

        public async Task<Result> Update(int vigilId, string firstName, string lastName, string phone, string adresse )
        {
            using( SqlConnection cnx = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@FirstName", firstName );
                p.Add( "@LastName", lastName );
                p.Add( "@Phone", phone );
                p.Add( "@Adresse", adresse );
                p.Add( "@status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await cnx.ExecuteAsync( "securevigil.sVigilUpdate", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Vigil not found" );
                Debug.Assert( status == 0 );
                return Result.Success( Status.Ok );

            }
        }
    }
}
