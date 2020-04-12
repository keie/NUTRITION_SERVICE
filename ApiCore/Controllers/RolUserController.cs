using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
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
            var obj = _unitOfWork.IRolUser.GetById(id);
            obj.User= _unitOfWork.IUser.GetById(obj.IdUser);
            obj.Rol= _unitOfWork.IRol.GetById(obj.IdRol);
            return Ok(obj);
        }
        [HttpGet]
       
        public IActionResult GetList()
        {
            var obj = _unitOfWork.IRolUser.GetList();
            List<RolUser> listRolUser= new List<RolUser>();
            foreach (var element in obj)
            {
                element.User= _unitOfWork.IUser.GetById(element.IdUser);
                element.Rol= _unitOfWork.IRol.GetById(element.IdRol);
                listRolUser.Add(element);
            }
            
            return Ok(listRolUser);
        }
    }
}