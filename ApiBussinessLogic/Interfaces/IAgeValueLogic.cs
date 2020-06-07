using System.Collections;
using System.Collections.Generic;
using ApiModel;

namespace ApiBussinessLogic.Interfaces
{
    public interface IAgeValueLogic
    {
        public int Insert(AgeValue obj);
        public IEnumerable<AgeValue> GetList();
        public AgeValue GetById(int id);
        public bool Update(AgeValue obj);
        public int DeleteAgeValue(int id);
    }
}