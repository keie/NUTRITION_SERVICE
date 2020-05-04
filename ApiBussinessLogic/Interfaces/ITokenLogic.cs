namespace ApiBussinessLogic.Interfaces{
    
    using ApiModel;
    using System.Collections.Generic;
    using JWT.Authentication;
    
    public interface ITokenLogic
    {
        JsonWebToken ProcessToken(User userLogin);
        
    }
}