using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF.REST.Hosting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployees" in both code and config file together.
    [ServiceContract(Namespace = "http://www.digitcyber.com/")]
    public interface IEmployees
    {
        [WebGet(UriTemplate = "all")]
        [Description("Get the list of all employees")] // <webHttp helpEnabled="true"/>
        IEnumerable<Employee> GetAll();

        [WebGet(UriTemplate = "{id}",
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml)]
        [Description("Get the employee by the given id")]
        Employee Get(string id);

        [WebInvoke(UriTemplate = "create", Method = "POST")]
        [Description("Create an employee")]
        void Create(Employee employee);

        [WebInvoke(UriTemplate = "update", Method = "PUT")]
        [Description("Update an employee")]
        void Update(Employee employee);

        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [Description("Update an employee's name")]
        void UpdateInfo(string id, string name);

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        [Description("Delete an employee by the given id")]
        void Delete(string id);
    }
}
