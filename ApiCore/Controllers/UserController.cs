



namespace ApiCore.Controllers {

    using System;
    using ApiModel;
    using Microsoft.AspNetCore.Mvc;
    using ApiBussinessLogic.Interfaces;
    [Route ("api/User")]
    public class UserController : Controller {
        
        private readonly IUserLogic _logic;
        
        public UserController (IUserLogic logic) {
            _logic = logic;
        }

        [HttpGet]
        [Route ("{id:int}")]
        public IActionResult GetById (int id) {
            return Ok (_logic.GetById (id));
        }

        [HttpGet]
        [Route ("GetListPaginated/{rows:int}/{pages:int}")]
        public IActionResult GetListPages (int rows, int pages) {
            try{
                return Ok(_logic.GetListPages(rows,pages));
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public IActionResult GetList(){
            try{
                return Ok(_logic.GetList());
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] User user){
            user.password=(_logic.EncryptPass(user.password));
            if(!ModelState.IsValid)return BadRequest(ModelState);
            try{
                return Ok(_logic.Insert(user));
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] User user){
            user.password=(_logic.EncryptPass(user.password));
            if(!ModelState.IsValid)return BadRequest(ModelState);
            try{
               return Ok(_logic.Update(user));
            }catch(Exception e){
                return BadRequest(e.Message);
            }
            
        }
        [HttpPost]
        [Route("validate")]
        public IActionResult validate([FromBody] User user){
            if(!ModelState.IsValid)return BadRequest(ModelState);
            try{
                var response=(_logic.ValidateUser(user.username,user.password));
                return Ok(response);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("encrypt")]
        public IActionResult Encrypt([FromBody] User user){
            return Ok(_logic.EncryptPass(user.password));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id){
            var response=(_logic.DeleteUser(id));
            if(response>0)return Ok(true);
            else return BadRequest(false);
        }
        
    }
}