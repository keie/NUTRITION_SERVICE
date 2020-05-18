using System.Collections.Generic;
using ApiModel;

namespace ApiBussinessLogic.Interfaces
{
    public interface ISizeValueLogic
    {
        public IEnumerable<SizeValue> GetList();
    }
}