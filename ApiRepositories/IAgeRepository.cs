using ApiModel;

namespace ApiRepositories
{
    public interface IAgeRepository:IRepository<AgeValue>
    {
        public int DeleteAgeValue(int id);
    }
}