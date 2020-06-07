using System;
using ApiBussinessLogic.Interfaces;
using ApiModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [Route("api/age")]
    public class AgeController:Controller
    {
        private readonly IAgeValueLogic _logic;

        public AgeController(IAgeValueLogic logic)
        {
            _logic = logic;
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] AgeValue obj)
        {
            try
            {
                return Ok(_logic.Insert(obj));
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
        public IActionResult Update([FromBody] AgeValue obj)
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
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_logic.DeleteAgeValue(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}