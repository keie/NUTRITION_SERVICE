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
            List<User> listUsersCharged = new List<User> ();
            listUsers = _unitOfWork.IUser.GetListPages (rows, pages);
            var listRolUser = _unitOfWork.IRolUser.GetList ();
            foreach (var user in listUsers) {
                List<Rol> listRoles = new List<Rol> ();
                foreach (var rolUser in listRolUser) {
                    if (user.id == rolUser.IdUser) {
                        listRoles.Add (_unitOfWork.IRol.GetById (rolUser.IdRol));
                    }
                }
                user.Roles = listRoles;
                listUsersCharged.Add (user);
            }
            return Ok (listUsersCharged);
        }
        [HttpGet]
        public IActionResult GetList(){
            var users=_unitOfWork.IUser.GetList();
            List<User> listUsersCharged = new List<User> ();
            try{
                foreach(var user in users){
                List<Rol> listRoles = new List<Rol> ();
                var roles=(_unitOfWork.IRolUser.GetList());
                foreach(var rol in roles){
                    if(user.id==rol.IdUser){
                        listRoles.Add((_unitOfWork.IRol.GetById(rol.IdRol)));
                    }
                }
                user.Roles=listRoles;
                listUsersCharged.Add(user);
            }
            return Ok(listUsersCharged);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] User user){
            Console.WriteLine("service on");
            if(!ModelState.IsValid)return BadRequest(ModelState);
            try{
                return Ok(_unitOfWork.IUser.Insert(user));
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] User user){
            Console.WriteLine("service on update");
            if(!ModelState.IsValid)return BadRequest(ModelState);
            try{
               
                return Ok(_unitOfWork.IUser.Update(user));
            }catch(Exception e){
                return BadRequest(e.Message);
            }
            
        }
        
    }
}