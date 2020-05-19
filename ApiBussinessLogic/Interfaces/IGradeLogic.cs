using System.Collections.Generic;
using ApiModel;

namespace ApiBussinessLogic.Interfaces
{
    public interface IGradeLogic
    {
        public IEnumerable<Grade> GetList();
        public int Insert(Grade obj);
        public bool Update(Grade obj);
        public Grade GetById(int id);
        public int DeleteGrade(int id);
    }
}