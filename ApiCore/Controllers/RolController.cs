

namespace ApiCore.Controllers{

    
    using Microsoft.AspNetCore.Mvc;
    using ApiBussinessLogic.Interfaces;

    [Route("api/Rol")]
    public class RolController:Controller{
        private readonly IRolLogic _logic;
        
        public RolController(IRolLogic logic){
            _logic=logic;
        }

        [HttpGet]
        public IActionResult GetList(){

            return Ok(_logic.GetList());
        }

    }
}