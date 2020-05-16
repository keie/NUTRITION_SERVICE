namespace ApiBussinessLogic.Implementations{
    
    using Interfaces;
    using ApiUnitWork;
    using ApiModel;
    using System.Collections.Generic;
    using JWT.Authentication;
    using System;
    
    public class TokenLogic:ITokenLogic{

        private readonly IUnitOfWork _unitOfWork;
        private ITokenProvider _tokenProvider;
        public TokenLogic(ITokenProvider tokenProvider,IUnitOfWork unitOfWork){
            _unitOfWork=unitOfWork;
            _tokenProvider = tokenProvider;
        }

        public JsonWebToken ProcessToken(User userLogin){
                List<Rol> Roles;
                var user = _unitOfWork.IUser.ValidateUser(userLogin.username, userLogin.password);
                Roles = new List<Rol>();
                var listRoles = _unitOfWork.IRolUser.GetList();
                foreach(var element in listRoles)
                {
                    if (user.id == element.IdUser)
                    {
                        Roles.Add(_unitOfWork.IRol.GetById(element.IdRol));
                    }
                }user.Roles = Roles;
                if (user == null)
                {
                    throw new UnauthorizedAccessException();
                }
                var token = new JsonWebToken
                {
                    Access_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(8)),
                    Expires_in = 480//minutes
                };
                return token;
        }
       
    }
}