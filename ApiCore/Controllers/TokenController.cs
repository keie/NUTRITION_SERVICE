

namespace ApiCore.Controllers
{
    using ApiModel;
    using ApiUnitWork;
    using Authentication;
    using Microsoft.AspNetCore.Mvc;
    using System;

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
            try
            {
                var user = _unitOfWork.IUser.ValidateUser(userLogin.Username, userLogin.Password);
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