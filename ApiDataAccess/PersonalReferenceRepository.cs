

using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace ApiDataAccess
{
    using ApiModel;
    using ApiRepositories;
    public class PersonalReferenceRepository:Repository<PersonalReference>,IPersonalReferenceRepository
    {
        
        public PersonalReferenceRepository(string connectionString):base(connectionString)
        {
            
        }

        public int DeletePersonalReference(int id)
        {
            var parameters=new DynamicParameters();
            parameters.Add("@id",id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("[DeletePersonalReference]",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            
        }
    }
}