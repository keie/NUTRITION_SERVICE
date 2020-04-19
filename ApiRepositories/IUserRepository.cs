using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiModel;

namespace ApiRepositories {
    public interface IUserRepository : IRepository<User> {
        User ValidateUser (string username, string password);
        IEnumerable<User> GetListPages (int rows, int pages);
    }
}