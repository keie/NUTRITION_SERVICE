using System.Collections;
using System.Collections.Generic;
using ApiBussinessLogic.Interfaces;
using ApiModel;
using ApiUnitWork;

namespace ApiBussinessLogic.Implementations
{
    public class KgValueLogic:IKgValueLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public KgValueLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<KgValue> GetList()
        {
            return (_unitOfWork.IKgValue.GetList());
        }

        public int Insert(KgValue obj)
        {
            return (_unitOfWork.IKgValue.Insert(obj));
        }

        public KgValue GetById(int id)
        {
            return (_unitOfWork.IKgValue.GetById(id));
        }

        public bool Update(KgValue obj)
        {
            return (_unitOfWork.IKgValue.Update(obj));
        }

        public int DeleteKgValue(int id)
        {
            return (_unitOfWork.IKgValue.DeleteKgValue(id));
        }
    }
}