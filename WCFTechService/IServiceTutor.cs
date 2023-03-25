using CommonLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFTechService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceTutor" in both code and config file together.
    [ServiceContract]
    public interface IServiceTutor
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/login/")]
        int Login(LoginContract login);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat =WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json,
            UriTemplate ="/getList/")]
        IList<StudentContract> GetStudentsList();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat =WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json,
            UriTemplate ="/add/")]
        string AddStudent(StudentContract student);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/update/{StudentId}")]
        string UpdateEmployee(StudentContract student, string studentId);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat =WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json,
            UriTemplate ="/delete/{StudentId}")]

        string DeleteStudent(string StudentId);

        
    }
}
