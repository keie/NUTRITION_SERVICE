

namespace ApiDataAccess
{
    using ApiModel;
    using ApiRepositories;
    using ApiUnitWork;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class UnitOfWork : IUnitOfWork
    {
        public IRolRepository IRol { get; set; }

        public IRolUserRepository IRolUser { get; set; }

        public IUserRepository IUser { get; set; }

        public UnitOfWork(string connectionString)
        {
            IRol = new RolRepository(connectionString);
            IUser=new UserRepository(connectionString);
            IRolUser=new RolUserRepository(connectionString);
        }
    }
}
