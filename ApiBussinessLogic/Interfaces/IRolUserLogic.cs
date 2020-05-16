namespace ApiBussinessLogic.Interfaces{
    using System.Collections.Generic;
    using ApiModel;
    using System;
    public interface IRolUserLogic
    {
        IEnumerable<RolUser> GetList();
        RolUser GetById(Int64 id);

       
    }
}