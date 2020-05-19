

namespace ApiUnitWork
{
    using ApiRepositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IUnitOfWork
    {
        IRolRepository IRol { get; }
        IRolUserRepository IRolUser { get; }
        IUserRepository IUser { get; }
        
        IPersonalReferenceRepository IPersonalReference { get; }
        
        IKgValueRepostitory IKgValue { get; }
        
        ISizeValueRepository ISizeValue { get; }
        
        IStatusNutritionGeneralRepository ISnutrition { get; }
        
        IGradeRepository IGrade { get; }
    }
}
