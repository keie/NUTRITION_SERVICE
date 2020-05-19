using System;
using ApiBussinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [Route("api/statusNutritionGeneral")]
    public class StatusNutritionGeneralController:Controller
    {
        private readonly IStatusNutritionGeneralLogic _logic;

        public StatusNutritionGeneralController(IStatusNutritionGeneralLogic logic)
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