using System.Collections.Generic;
using ApiBussinessLogic.Interfaces;
using ApiModel;
using ApiUnitWork;

namespace ApiBussinessLogic.Implementations
{
    public class SizeValueLogic:ISizeValueLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public SizeValueLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SizeValue> GetList()
        {
            return (_unitOfWork.ISizeValue.GetList());
        }
        
        
        public SizeValue GetById(int id)
        {
            return (_unitOfWork.ISizeValue.GetById(id));
        }

        public int Insert(SizeValue obj)
        {
            return (_unitOfWork.ISizeValue.Insert(obj));
        }

        public bool Update(SizeValue obj)
        {
            return (_unitOfWork.ISizeValue.Update(obj));
        }

        public int DeleteSizeValue(int id)
        {
            return (_unitOfWork.ISizeValue.DeleteSizeValue(id));
        }
    }
}