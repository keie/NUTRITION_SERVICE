

namespace ApiRepositories
{
    using ApiModel;
    public interface IKgValueRepostitory: IRepository<KgValue>
    {
        public int DeleteKgValue(int id);
    }
}