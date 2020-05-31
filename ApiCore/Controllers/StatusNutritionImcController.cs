using System;
using ApiBussinessLogic.Interfaces;
using ApiModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [Route("api/imc")]
    public class StatusNutritionImcController:Controller
    {
        private readonly IStatusNutritionImcLogic _logic;

        public StatusNutritionImcController(IStatusNutritionImcLogic logic)
        {
            _logic = logic;
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] StatusNutritionImc obj)
        {
            try
            {
                var request = _logic.Insert(obj);
                if (request == 0) throw new Exception("operation failed");
                return Ok(obj);
            }
            catch (Exception e)
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
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_logic.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] StatusNutritionImc obj)
        {
            try
            {
                return Ok(_logic.Update(obj));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("delete/{id:int}")]
        public IActionResult Update(int id)
        {
            try
            {
                return Ok(_logic.DeleteImc(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}