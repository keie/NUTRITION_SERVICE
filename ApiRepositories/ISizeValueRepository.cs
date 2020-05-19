using ApiModel;

namespace ApiRepositories
{
    public interface ISizeValueRepository:IRepository<SizeValue>
    {
        public int DeleteSizeValue(int id);
    }
}