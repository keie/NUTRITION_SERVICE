

namespace ApiCore.Controllers
{
    using ApiModel;
    using ApiUnitWork;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using ApiBussinessLogic.Interfaces;
    using JWT.Authentication;

    [Route("api/token")]
    public class TokenController : Controller
    {
       
       
        private readonly ITokenLogic _logic;

        public TokenController(ITokenLogic logic){
            _logic=logic;
        }
        
        [HttpPost]
        public   IActionResult ProcessToken([FromBody]User userLogin)
        {
            try
            {
                return Ok(_logic.ProcessToken(userLogin));
            }
            catch(Exception e)
            {
                var token = new JsonWebToken
                {
                    Message = e.Message
                };
                return BadRequest(token);
            }
        }
    }
}