

namespace ApiCore.Controllers
{
    using ApiModel;
    using ApiUnitWork;
    using Authentication;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Route("api/token")]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unitOfWork;


        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unitOfWork)
        {
            this._tokenProvider = tokenProvider;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public JsonWebToken Post([FromBody]User userLogin)
        {
            List<Rol> Roles;
            try
            {
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
            }catch(Exception e)
            {
                var token = new JsonWebToken
                {
                    Message = e.Message
                };
                return (token);
            }
        }
    }
}