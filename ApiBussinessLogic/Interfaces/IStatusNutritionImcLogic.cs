using System.Collections;
using System.Collections.Generic;
using ApiModel;

namespace ApiBussinessLogic.Interfaces
{
    public interface IStatusNutritionImcLogic
    {
        public int Insert(StatusNutritionImc obj);
        public IEnumerable<StatusNutritionImc> GetList();
        public StatusNutritionImc GetById(int id);

        public bool Update(StatusNutritionImc obj);
        public int DeleteImc(int id);
    }
}