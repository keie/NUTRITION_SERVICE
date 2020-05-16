namespace ApiBussinessLogic.Implementations{
    using Interfaces;
    using ApiModel;
    using System;
    using System.Collections.Generic;
    using ApiUnitWork;
    
    public class RolLogic:IRolLogic{

        private readonly IUnitOfWork _unitOfWork;
        public RolLogic(IUnitOfWork unitOfWork){
            _unitOfWork=unitOfWork;
        }
        public bool Delete(Rol rol){
            throw new NotImplementedException();
        }
        public bool Update(Rol rol){
            throw new NotImplementedException();
        }
        public int Insert(Rol rol){
            throw new NotImplementedException();
        }
        public IEnumerable<Rol> GetList(){
            return _unitOfWork.IRol.GetList();
        }
        public Rol GetById(Int64 id){
            return _unitOfWork.IRol.GetById(id);
        }
    }
}