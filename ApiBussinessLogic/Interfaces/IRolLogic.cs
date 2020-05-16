namespace ApiBussinessLogic.Interfaces{
    using ApiModel;
    using System.Collections.Generic;
    using System;
    public interface IRolLogic{
        bool Delete(Rol rol);
        bool Update(Rol rol);
        int Insert(Rol rol);
        IEnumerable<Rol> GetList();
        Rol GetById(Int64 id);
    }
}