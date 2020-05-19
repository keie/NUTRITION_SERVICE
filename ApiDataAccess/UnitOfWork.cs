

namespace ApiDataAccess
{
    using ApiModel;
    using ApiRepositories;
    using ApiUnitWork;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class UnitOfWork : IUnitOfWork
    {
        public IRolRepository IRol { get; set; }

        public IRolUserRepository IRolUser { get; set; }

        public IUserRepository IUser { get; set; }
        
        public IPersonalReferenceRepository IPersonalReference { get; set; }
        
        public IKgValueRepostitory IKgValue { get; set; }
        
        public ISizeValueRepository ISizeValue { get; set; }
        
        public IStatusNutritionGeneralRepository ISnutrition { get; set; }

        public IGradeRepository IGrade { get; }

        public UnitOfWork(string connectionString)
        {
            IRol = new RolRepository(connectionString);
            IUser=new UserRepository(connectionString);
            IRolUser=new RolUserRepository(connectionString);
            IPersonalReference=new PersonalReferenceRepository(connectionString);
            IKgValue=new KgValueRepository(connectionString);
            ISizeValue=new SizeValueRepository(connectionString);
            ISnutrition=new StatusNutritionGeneralRepository(connectionString);
            IGrade=new GradeRepository(connectionString);
        }
    }
}
