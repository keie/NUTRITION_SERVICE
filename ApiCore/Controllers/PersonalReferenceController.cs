

namespace ApiCore.Controllers
{
    using System;
    using ApiModel;
    using Microsoft.AspNetCore.Mvc;
    using ApiBussinessLogic.Interfaces;
    
    [Route("api/personalReference")]
    public class PersonalReferenceController:Controller
    {
        private readonly IPersonalReferenceLogic _logic;

        public PersonalReferenceController(IPersonalReferenceLogic logic)
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
        public IActionResult Insert([FromBody] PersonalReference pr)
        {
            try
            {
                return Ok(_logic.Insert(pr));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}