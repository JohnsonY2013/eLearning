using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;

namespace WCF.REST.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Employee" in both code and config file together.
    public class Employees : IEmployees
    {
        private static IList<Employee> _employees = new List<Employee>
        {
            new Employee {Id="001", Name="Jack", Department="HR", Grade="G7"},
            new Employee {Id="002", Name="Tom", Department="IT", Grade="G8" }
        };

        public void Create(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Delete(string id)
        {
            var employee = this.Get(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }

        public Employee Get(string id)
        {
            var employee = _employees.FirstOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));

            if (employee == null)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode
                    = System.Net.HttpStatusCode.NotFound;
            }
            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public void Update(Employee employee)
        {
            var existingEmployee = this.Get(employee.Id);
            existingEmployee.Name = employee.Name;
            existingEmployee.Department = employee.Department;
            existingEmployee.Grade = employee.Grade;
        }

        public void UpdateInfo(string id, string name)
        {
            var existingEmployee = this.Get(id);
            existingEmployee.Name = name;
        }
    }
}
