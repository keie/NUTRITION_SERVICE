using System.Collections;
using System.Collections.Generic;
using ApiBussinessLogic.Interfaces;
using ApiModel;
using ApiUnitWork;

namespace ApiBussinessLogic.Implementations
{
    public class StatusNutritionLogic:IStatusNutritionImcLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusNutritionLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Insert(StatusNutritionImc obj)
        {
            return (_unitOfWork.IStatusImc.Insert(obj));
        }

        public IEnumerable<StatusNutritionImc> GetList()
        {
            return (_unitOfWork.IStatusImc.GetList());
        }

        public StatusNutritionImc GetById(int id)
        {
            return (_unitOfWork.IStatusImc.GetById(id));
        }

        public bool Update(StatusNutritionImc obj)
        {
            return (_unitOfWork.IStatusImc.Update(obj));
        }

        public int DeleteImc(int id)
        {
            return (_unitOfWork.IStatusImc.DeleteImc(id));
        }
    }
}