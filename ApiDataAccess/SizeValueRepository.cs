using ApiModel;
using ApiRepositories;

namespace ApiDataAccess
{
    public class SizeValueRepository:Repository<SizeValue>,ISizeValueRepository
    {
        public SizeValueRepository(string connectionString):base(connectionString)
        {
            
        }
    }
}