using System.Collections.Generic;

namespace ApiBussinessLogic.Interfaces
{
    using ApiModel;
    public interface IPersonalReferenceLogic
    {
        IEnumerable<PersonalReference> GetList();
        PersonalReference GetById(int id);
        
        int Insert(PersonalReference obj);

        bool Update(PersonalReference obj);

        public int DeletePersonalReference(int id);

    }
}