

namespace ApiCore.Controllers
{
    using ApiUnitWork;
    using Authentication;
    using Microsoft.AspNetCore.Mvc;

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
    }
}