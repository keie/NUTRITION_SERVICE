using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiModel;
using ApiUnitWork;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers{

    [Route("api/Rol")]
    public class RolController:Controller{
        private readonly IUnitOfWork _unitOfWork;
        
        public RolController(IUnitOfWork unitOfWork){
            _unitOfWork=unitOfWork;
        }

        [HttpGet]
        public IActionResult GetList(){

            return Ok(_unitOfWork.IRol.GetList());
        }

    }
}