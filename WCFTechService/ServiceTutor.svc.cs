using BusinessLayer;
using CommonLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTechService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceTutor" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceTutor.svc or ServiceTutor.svc.cs at the Solution Explorer and start debugging.
    public class ServiceTutor : IServiceTutor
    {
        BusinessClass businessClass = new BusinessClass();
         public int Login(LoginContract login)
        {
            try
            {
                return businessClass.Login(login);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<StudentContract> GetStudentsList()
        {
            IList<StudentContract> studentContracts = businessClass.GetStudentsList();
            if(studentContracts != null)
            {
                return studentContracts;
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
                return businessClass.AddStudent(student);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateEmployee(StudentContract student, string StudentId)
        {
            try
            {
                int StuId = Convert.ToInt32(StudentId);
                return businessClass.UpdateStudent(student, StuId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteStudent(string StudentId)
        {
            try
            {
                int StuId = Convert.ToInt32(StudentId);
                return businessClass.DeleteStudent(StuId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
