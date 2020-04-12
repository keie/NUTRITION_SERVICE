

namespace ApiUnitWork
{
    using ApiRepositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IUnitOfWork
    {
        IRolRepository IRol { get; }
        IRolUserRepository IRolUser { get; }
        IUserRepository IUser { get; }
    }
}
