using CommonLayer.Contracts;
using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class StudentClass : IStudentClass
    {
        TutorDBEntities tutorDBEntities;
        public StudentClass()
        {
            tutorDBEntities = new TutorDBEntities();
        }
        public int Login(LoginContract login)
        {
            try
            {
                var result = tutorDBEntities.AdminCredentials.Where(x=> x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
                if (result != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IList<StudentContract> GetStudentsList()
        {
            try
            {
                var query = (from a in tutorDBEntities.StudentDetails select a).Distinct();
                List<StudentContract> details = new List<StudentContract>();

                query.ToList().ForEach(x =>
                {
                    details.Add(new StudentContract
                    {
                        Id = x.ID,
                        Name = x.Name,
                        Email = x.Email,
                        Password = x.Password,
                        CourseName = x.CourseName,
                        Duration = x.Duration,
                    });
                });
                return details;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AddStudent(StudentContract student)
        {
            try
            {
                StudentDetail studentDetail = new StudentDetail()
                {
                    Name = student.Name,
                    Email = student.Email,
                    Password = student.Password,
                    CourseName = student.CourseName,
                    Duration = student.Duration,
                };
                tutorDBEntities.StudentDetails.Add(studentDetail);
                return tutorDBEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public StudentContract GetStudentByEmail(string email)
        {
            StudentDetail studentDetail = (from a in tutorDBEntities.StudentDetails 
                                           where a.Email == email 
                                           select a).FirstOrDefault();
            if (studentDetail != null)
            {
                StudentContract contract = new StudentContract()
                {
                    Name=studentDetail.Name,
                    Email  =studentDetail.Email,
                    Password=studentDetail.Password,
                    CourseName=studentDetail.CourseName,
                    Duration=studentDetail.Duration,
                };
                return contract;
            }
            return null;
        }
        public int UpdateStudent(StudentContract student, int StudentId)
        {
            StudentDetail studentDetail = tutorDBEntities.StudentDetails.Find(StudentId);
            if (studentDetail != null)
            {
                studentDetail.Name = student.Name;
                studentDetail.Email = student.Email;
                studentDetail.Password = student.Password;
                studentDetail.CourseName = student.CourseName;
                studentDetail.Duration = student.Duration;
                return tutorDBEntities.SaveChanges();
            }
            else
            {
                throw new Exception("Student do not exists");
            }
        }
        public int DeleteStudent(int StudentId)
        {
            var student = (from a in tutorDBEntities.StudentDetails
                           where a.ID == StudentId
                           select a).FirstOrDefault();
            if(student != null)
            {
                tutorDBEntities.StudentDetails.Remove(student);
                return tutorDBEntities.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
