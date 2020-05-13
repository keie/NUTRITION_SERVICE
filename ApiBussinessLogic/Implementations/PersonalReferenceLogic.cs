

namespace ApiBussinessLogic.Implementations
{
    using System.Collections.Generic;
    using ApiBussinessLogic.Interfaces;
    using ApiModel;
    using ApiUnitWork;
    public class PersonalReferenceLogic:IPersonalReferenceLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public PersonalReferenceLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IEnumerable<PersonalReference> GetList()
        {
            return (_unitOfWork.IPersonalReference.GetList());
        }

        public PersonalReference GetById(int id)
        {
            return (_unitOfWork.IPersonalReference.GetById(id));
        }

        public int Insert(PersonalReference obj)
        {
            return (_unitOfWork.IPersonalReference.Insert(obj));
        }

        public bool Update(PersonalReference obj)
        {
            return (_unitOfWork.IPersonalReference.Update(obj));
        }

        public int DeletePersonalReference(int id)
        {
            return (_unitOfWork.IPersonalReference.DeletePersonalReference(id));
        }
    }
}