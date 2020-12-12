using CoreCRUDwithOracle.Models;
using System.Collections.Generic;

namespace CoreCRUDwithOracle.Interface
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudent();
        Student GetStudentById(int eid);
        void AddStudent(Student student);
        void EditStudent(Student student);
        void DeleteStudent(Student student);
    }
}