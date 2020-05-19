using System.Collections.Generic;
using ApiModel;

namespace ApiBussinessLogic.Interfaces
{
    public interface ISizeValueLogic
    {
        public IEnumerable<SizeValue> GetList();
        public SizeValue GetById(int id);

        public int Insert(SizeValue obj);

        public bool Update(SizeValue obj);

        public int DeleteSizeValue(int id);
    }
}