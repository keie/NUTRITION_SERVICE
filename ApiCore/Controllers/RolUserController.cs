

namespace ApiCore.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using ApiBussinessLogic.Interfaces;
    [Route("api/RolUser")]
    public class RolUserController : Controller
    {
        private readonly IRolUserLogic _logic;

        public RolUserController(IRolUserLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(Int64 id)
        {
            try
            {
                return Ok(_logic.GetById(id));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
               return Ok(_logic.GetList());
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}