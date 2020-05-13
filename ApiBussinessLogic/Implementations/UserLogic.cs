namespace ApiBussinessLogic.Implementations{
    
    using Interfaces;
    using ApiModel;
    using System.Collections.Generic;
    using System;
    using ApiUnitWork;
    public class UserLogic: IUserLogic{

        private readonly IUnitOfWork _unitOfWork;
        public UserLogic(IUnitOfWork unitOfWork){
            _unitOfWork=unitOfWork;
        }
        
        public User ValidateUser(string name,string password){
            return _unitOfWork.IUser.ValidateUser(name,password);
        }

        public IEnumerable<User> GetListPages(int rows,int pages){
            IEnumerable<User> listUsers = new List<User> ();
            List<User> listUsersCharged = new List<User> ();
            listUsers = _unitOfWork.IUser.GetListPages (rows, pages);
            var listRolUser = _unitOfWork.IRolUser.GetList();
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
            return listUsersCharged;
        }

        public string EncryptPass(string password){
            return _unitOfWork.IUser.EncryptPass(password);
        }

        public int DeleteUser(int id){
            return _unitOfWork.IUser.DeleteUser(id);
        }

        public int Insert(User user){
            return (_unitOfWork.IUser.Insert(user));
        }

        public bool Update(User user){
            return (_unitOfWork.IUser.Update(user));
        }

        public string Encrypt(User user){
            return(_unitOfWork.IUser.EncryptPass(user.password));
        }

        public User GetById(Int64 id)
        {
            var req = _unitOfWork.IUser.GetById(id);
            return (req);
        }

        public IEnumerable<User> GetList(){
            Console.WriteLine("method");
            var users=_unitOfWork.IUser.GetList();
            List<User> listUsersCharged = new List<User> ();
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
            return listUsersCharged;
        }
    }
}