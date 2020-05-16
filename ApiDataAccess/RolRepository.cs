using ApiModel;
using ApiRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDataAccess
{
    public class RolRepository: Repository<Rol>, IRolRepository
    {
        public RolRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
