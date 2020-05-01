using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiModel;
using ApiUnitWork;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [Route("api/RolUser")]
    public class RolUserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolUserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(Int64 id)
        {
            try
            {
                var obj = _unitOfWork.IRolUser.GetById(id);
                if (obj == null)
                {
                    throw new Exception("Does not exist register");
                }
                obj.User = _unitOfWork.IUser.GetById(obj.IdUser);
                obj.Rol = _unitOfWork.IRol.GetById(obj.IdRol);
                return Ok(obj);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                var obj = _unitOfWork.IRolUser.GetList();
                List<RolUser> listRolUser = new List<RolUser>();
                foreach (var element in obj)
                {
                    element.User = _unitOfWork.IUser.GetById(element.IdUser);
                    element.Rol = _unitOfWork.IRol.GetById(element.IdRol);
                    listRolUser.Add(element);
                }
                return Ok(listRolUser);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}