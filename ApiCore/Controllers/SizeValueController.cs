using System;
using System.Drawing;
using ApiBussinessLogic.Interfaces;
using ApiModel;
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

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] SizeValue obj)
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

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] SizeValue obj)
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
                return Ok(_logic.DeleteSizeValue(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}