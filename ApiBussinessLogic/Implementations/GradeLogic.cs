using System.Collections.Generic;
using ApiBussinessLogic.Interfaces;
using ApiModel;
using ApiUnitWork;

namespace ApiBussinessLogic.Implementations
{
    public class GradeLogic:IGradeLogic
    {
        
        private readonly IUnitOfWork _unitOfWorK;

        public GradeLogic(IUnitOfWork unitOfWorK)
        {
            _unitOfWorK = unitOfWorK;
        }

        public IEnumerable<Grade> GetList()
        {
            return (_unitOfWorK.IGrade.GetList());
        }

        public int Insert(Grade obj)
        {
            return (_unitOfWorK.IGrade.Insert(obj));
        }

        public bool Update(Grade obj)
        {
            return (_unitOfWorK.IGrade.Update(obj));
        }

        public Grade GetById(int id)
        {
            return (_unitOfWorK.IGrade.GetById(id));
        }

        public int DeleteGrade(int id)
        {
            return (_unitOfWorK.IGrade.DeleteGrade(id));
        }
    }
}