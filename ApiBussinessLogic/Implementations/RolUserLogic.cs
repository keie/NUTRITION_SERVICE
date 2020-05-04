namespace ApiBussinessLogic.Implementations{
    using Interfaces;
    using System.Collections.Generic;
    using System;
    using ApiModel;
    using ApiUnitWork;
    public class RolUserLogic:IRolUserLogic{
        private readonly IUnitOfWork _unitOfWork;

        public RolUserLogic(IUnitOfWork unitOfWork){
            _unitOfWork=unitOfWork;
        }

        public IEnumerable<RolUser> GetList(){
            var obj = _unitOfWork.IRolUser.GetList();
                List<RolUser> listRolUser = new List<RolUser>();
                foreach (var element in obj)
                {
                    element.User = _unitOfWork.IUser.GetById(element.IdUser);
                    element.Rol = _unitOfWork.IRol.GetById(element.IdRol);
                    listRolUser.Add(element);
                }
            return (listRolUser);
        }

        public RolUser GetById(Int64 id){
            var obj = _unitOfWork.IRolUser.GetById(id);
            if (obj == null)
            {
                throw new Exception("Does not exist register");
            }
            obj.User = _unitOfWork.IUser.GetById(obj.IdUser);
            obj.Rol = _unitOfWork.IRol.GetById(obj.IdRol);
            return obj;
        }

    }
}