
namespace ApiBussinessLogic.Interfaces
{
    using System.Collections.Generic;
    using ApiModel;

    public interface IStatusNutritionGeneralLogic
    {
        public IEnumerable<StatusNutritionGeneral> GetList();
    }
}