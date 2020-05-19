using System.Collections.Generic;
using ApiModel;
using ApiRepositories;

namespace ApiDataAccess
{
    public class StatusNutritionGeneralRepository:Repository<StatusNutritionGeneral>,IStatusNutritionGeneralRepository
    {
        public StatusNutritionGeneralRepository(string connectionString): base(connectionString)
        {
            
        }
        
        
    }
}