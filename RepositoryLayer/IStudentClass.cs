using CommonLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IStudentClass
    {
        int Login(LoginContract login);
        IList<StudentContract> GetStudentsList();

        int AddStudent(StudentContract student);

        StudentContract GetStudentByEmail(string email);
        int UpdateStudent(StudentContract student, int StudentId);

        int DeleteStudent(int StudentId);
    }
}
