

namespace ApiDataAccess
{
    using ApiModel;
    using ApiRepositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
