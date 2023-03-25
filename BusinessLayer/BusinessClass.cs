using BusinessLayer.Interface;
using CommonLayer.Contracts;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessClass : IBusinessClass
    {
        StudentClass studentClass = new StudentClass();
        public int Login(LoginContract login)
        {
            try
            {
                return studentClass.Login(login);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<StudentContract> GetStudentsList()
        {
            IList<StudentContract> studentDetails = studentClass.GetStudentsList();
            if(studentDetails != null)
            {
                return studentDetails;
            }
            else
            {
                return new List<StudentContract>();
            }
        }
        public string AddStudent(StudentContract student)
        {
            try
            {
                if(studentClass.GetStudentByEmail(student.Email) != null)
                {
                    return "Mail Id is already registered, please try with another email id";
                }
                if(studentClass.AddStudent(student) == 1)
                {
                    return "Student added successfully";
                }
                else
                {
                    return "Not able to add this student";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateStudent(StudentContract student, int StudentId)
        {
            if (studentClass.UpdateStudent(student, StudentId) == 1)
            {
                return "Student updated successfully";
            }
            else
            {
                return "Student is not updated";
            }
        }
        public string DeleteStudent(int StudentId)
        {
            if (studentClass.DeleteStudent(StudentId) == 1)
            {
                return "Student deleted successfully";
            }
            else
            {
                return "Student does not exists";
            }
        }
    }
}
