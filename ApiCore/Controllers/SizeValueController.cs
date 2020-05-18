using System;
using ApiBussinessLogic.Interfaces;
using ApiUnitWork;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [Route("api/sizevalue")] 
    public class SizeValueController:Controller
    {
        private readonly ISizeValueLogic _logic;

        public SizeValueController(ISizeValueLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_logic.GetList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}