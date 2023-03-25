using CommonLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IBusinessClass
    {
        int Login(LoginContract login);
        IList<StudentContract> GetStudentsList();
        string AddStudent(StudentContract student);
        string UpdateStudent(StudentContract student, int StudentId);

        string DeleteStudent(int StudentId);
    }
}
