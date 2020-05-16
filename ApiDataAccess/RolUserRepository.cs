

namespace ApiDataAccess
{
    using ApiModel;
    using ApiRepositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class RolUserRepository: Repository<RolUser>,IRolUserRepository
    {
        public RolUserRepository(string connectionString):base(connectionString)
        {

        }
    }
}
