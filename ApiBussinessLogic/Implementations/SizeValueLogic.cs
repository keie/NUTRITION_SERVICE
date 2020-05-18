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
    }
}