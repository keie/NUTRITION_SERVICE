using System.Collections;
using System.Collections.Generic;
using ApiBussinessLogic.Interfaces;
using ApiModel;
using ApiUnitWork;

namespace ApiBussinessLogic.Implementations
{
    public class AgeLogic:IAgeValueLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public AgeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Insert(AgeValue obj)
        {
            return (_unitOfWork.IAge.Insert(obj));
        }

        public IEnumerable<AgeValue> GetList()
        {
            return (_unitOfWork.IAge.GetList());
        }

        public AgeValue GetById(int id)
        {
            return (_unitOfWork.IAge.GetById(id));
        }

        public bool Update(AgeValue obj)
        {
            return (_unitOfWork.IAge.Update(obj));
        }

        public int DeleteAgeValue(int id)
        {
            return (_unitOfWork.IAge.DeleteAgeValue(id));
        }
    }
}