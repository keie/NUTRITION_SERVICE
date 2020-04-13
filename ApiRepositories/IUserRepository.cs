using ApiModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRepositories
{
    public interface IUserRepository:IRepository<User>
    {
        User ValidateUser(string username, string password);
    }
}
