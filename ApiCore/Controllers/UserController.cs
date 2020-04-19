using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiModel;
using ApiUnitWork;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers {
    [Route ("api/User")]
    public class UserController : Controller {
        private readonly IUnitOfWork _unitOfWork;

        public UserController (IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route ("{id:int}")]
        public IActionResult GetById (int id) {
            return Ok (_unitOfWork.IUser.GetById (id));
        }

        [HttpGet]
        [Route ("GetListPaginated/{rows:int}/{pages:int}")]
        public IActionResult GetListPaged (int rows, int pages) {
            IEnumerable<User> listUsers = new List<User> ();
            listUsers = _unitOfWork.IUser.GetListPages (rows, pages);
            return Ok (listUsers);
        }
    }
}