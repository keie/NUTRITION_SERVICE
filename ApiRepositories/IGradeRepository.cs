using ApiModel;

namespace ApiRepositories
{
    public interface IGradeRepository:IRepository<Grade>
    {
        public int DeleteGrade(int id);
    }
}