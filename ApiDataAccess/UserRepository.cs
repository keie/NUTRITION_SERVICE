

namespace ApiDataAccess
{
    using ApiModel;
    using ApiRepositories;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text;
    using ApiCore.Encrypt;

    public class UserRepository: Repository<User>, IUserRepository
    {
        private Encrypt _encryptionService;
        public UserRepository(string connectionString) : base(connectionString)
        {

        }

        public User ValidateUser(string username, string password)
        {
            string passFormat = "SHA512";
            string saltKey = "";
            UserPassword userPassword = new UserPassword();
            userPassword = GetPassword(username);
            if (userPassword != null)
            {
                saltKey = userPassword.PasswordSalt;
            }
            _encryptionService = new Encrypt();
            password = _encryptionService.CreatePasswordHash(password, saltKey, passFormat);
            var parameters = new DynamicParameters();
            parameters.Add("@username", username);
            parameters.Add("@password", password);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<User>(
                    "dbo.[ValidateUser]", parameters,
                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public UserPassword GetPassword(string username)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@username", username);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<UserPassword>(
                    "dbo.[UserByUsername]", parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
