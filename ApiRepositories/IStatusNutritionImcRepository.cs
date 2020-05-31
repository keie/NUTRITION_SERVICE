using ApiModel;

namespace ApiRepositories
{
    public interface IStatusNutritionImcRepository:IRepository<StatusNutritionImc>
    {
        public int DeleteImc(int id);
    }
}