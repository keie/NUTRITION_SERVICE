

namespace ApiDataAccess
{
    using ApiModel;
    using ApiRepositories;
    public class PersonalReferenceRepository:Repository<PersonalReference>,IPersonalReferenceRepository
    {
        
        public PersonalReferenceRepository(string connectionString):base(connectionString)
        {
            
        }
    }
}