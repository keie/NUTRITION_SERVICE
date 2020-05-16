using System;
using ApiBussinessLogic.Interfaces;
using ApiModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [Route("api/kgvalue")]
    public class KgValueController:Controller
    {
        private readonly IKgValueLogic _logic;

        public KgValueController(IKgValueLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return Ok(_logic.GetList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] KgValue obj)
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
        public IActionResult Update([FromBody] KgValue obj)
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
                return Ok(_logic.DeleteKgValue(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}