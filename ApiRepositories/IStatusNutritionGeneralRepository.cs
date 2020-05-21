using System.Collections.Generic;
using System.Configuration;
using ApiModel;

namespace ApiRepositories
{
    public interface IStatusNutritionGeneralRepository:IRepository<StatusNutritionGeneral>
    {
        //public int ValidateInsertValues(int idPreference, int idGrade, int idSizeValue, int idKgValue);
        public int DeleteStatusNutritionGeneral(int id);

    }
}