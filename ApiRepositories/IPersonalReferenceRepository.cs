

namespace ApiRepositories
{
    using ApiModel;
    public interface IPersonalReferenceRepository: IRepository<PersonalReference>
    {
        public int DeletePersonalReference(int id);
    }
}