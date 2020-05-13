using System;

namespace ApiBussinessLogic.Interfaces{
    
    using ApiModel;
    using System.Collections.Generic;
    public interface IUserLogic{
        User ValidateUser (string username, string password);
        IEnumerable<User> GetListPages (int rows, int pages);
        string EncryptPass (string _password);
        int DeleteUser(int id);
        int Insert(User user);
        bool Update(User user);
        string Encrypt(User user);
        IEnumerable<User> GetList();

        User GetById(Int64 id);
    }
}