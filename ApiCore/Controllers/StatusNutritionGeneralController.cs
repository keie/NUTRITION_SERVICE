using System;
using ApiBussinessLogic.Interfaces;
using ApiModel;
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

        /*[HttpGet]
        public IActionResult ValidateInsertValues(int idPreference, int idGrade, int idSizeValue, int idKgValue)
        {
            try
            {
                return Ok(_logic.ValidateInsertValues(idPreference, idGrade, idSizeValue, idKgValue));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/
        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] StatusNutritionGeneral obj)
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

        [HttpDelete]
        [Route("delete/{id:int}")]
        public IActionResult DeleteStatusNutritionGeneral(int id)
        {
            try
            {
                return Ok(_logic.DeleteStatusNutritionGeneral(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}