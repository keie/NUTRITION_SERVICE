
namespace ApiBussinessLogic.Interfaces
{
    using System.Collections.Generic;
    using ApiModel;

    public interface IStatusNutritionGeneralLogic
    {
        public IEnumerable<StatusNutritionGeneral> GetList();
        //public int ValidateInsertValues(int idPreference, int idGrade, int idSizeValue, int idKgValue);
        public int Insert(StatusNutritionGeneral obj);

        public StatusNutritionGeneral GetById(int id);

        public int DeleteStatusNutritionGeneral(int id);
    }
}