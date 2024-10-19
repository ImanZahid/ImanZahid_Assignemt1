using BLL.DAL;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class StudentService : Service, IStudentService
    {
        public StudentService(DB studentsDBContext) : base(studentsDBContext)
        {
        }

        public Service Create(Student Student)
        {
            bool exist = StudentsDBContext.Students.Any(student => student.Id == student.Id);

            if (exist) {
                return Error("Student Existsssssss!!!!!");
            }

            StudentsDBContext.Students.Add(Student);
            StudentsDBContext.SaveChanges();

            return Success("Student ADDEDDDD!!!!!");
        }

        public Service Delete(int id)
        {
           Student student = StudentsDBContext.Students.Select(student => student).Where(student => student.Id == id).FirstOrDefault();

            if (student != null) { 
                StudentsDBContext.Students.Remove(student);
                StudentsDBContext.SaveChanges();
                return Success("Success!!!");
            }
            return Error("ERRORRRR!!!");
        }

        public IQueryable<StudentModel> Query()
        {
            return StudentsDBContext.Students.OrderBy(student => student.Name).Select(student => new StudentModel { Student = student }); 
                
        }

        public Service Update(Student Student)
        {
            bool exist = StudentsDBContext.Students.Any(student => student.Id == student.Id);

            if (!exist)
            {
                return Error("Student doesn't exist!!!!!");
            }
            StudentsDBContext.Students.Update(Student);
            StudentsDBContext.SaveChanges();
            return Success("Student Updateddd!!!!");
        }
    }
}
