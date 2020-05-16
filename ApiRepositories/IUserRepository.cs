

namespace ApiRepositories {
   
    using System.Collections.Generic;
    using ApiModel;
    public interface IUserRepository : IRepository<User> {
        User ValidateUser (string username, string password);
        IEnumerable<User> GetListPages (int rows, int pages);

        string EncryptPass (string _password);

        int DeleteUser(int id);
    }
}