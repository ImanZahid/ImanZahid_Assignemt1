using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;


namespace BLL.Interfaces
{
     public interface IStudentService
    {

        public Service Create(Student Student);

        public Service Update(Student Student);

        public Service Delete(int id);

        public IQueryable<StudentModel> Query();
        
    }
}
