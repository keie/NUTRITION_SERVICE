

namespace ApiBussinessLogic.Interfaces
{
    using System.Collections.Generic;
    using ApiModel;
    public interface IKgValueLogic
    {
        IEnumerable<KgValue> GetList();
        int Insert(KgValue obj);

        KgValue GetById(int id);

        bool Update(KgValue obj);

        int DeleteKgValue(int id);
    }
}