using System;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
//using WCF.REST.Client.EmployeeServices;

namespace WCF.REST.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CallByDll();
            Console.WriteLine();
            CallByWeb();
            Console.WriteLine();
            Console.ReadLine();
        }

        static void CallByDll()
        {
            using (var channelFactory = new ChannelFactory<WCF.REST.Services.IEmployees>("employeeService"))
            {
                var proxy = channelFactory.CreateChannel();

                Console.WriteLine("所有员工列表：");
                var allEmployees = proxy.GetAll();
                Array.ForEach(allEmployees.ToArray(), employee => Console.WriteLine(employee.ToString()));
                
                Console.WriteLine("\n添加一个新员工（003）：");
                proxy.Create(new WCF.REST.Services.Employee
                {
                    Id = "003",
                    Name = "王五",
                    Grade = "G9",
                    Department = "行政部"
                });

                Console.WriteLine("所有员工列表：");
                allEmployees = proxy.GetAll();
                Array.ForEach(allEmployees.ToArray(), employee => Console.WriteLine(employee.ToString()));

                Console.WriteLine("\n修改员工（003）信息：");
                proxy.Update(new WCF.REST.Services.Employee
                {
                    Id = "003",
                    Name = "王五",
                    Grade = "G11",
                    Department = "销售部"
                });

                Console.WriteLine("所有员工列表：");
                allEmployees = proxy.GetAll();
                Array.ForEach(allEmployees.ToArray(), employee => Console.WriteLine(employee.ToString()));

                Console.WriteLine("\n修改员工（003）姓名：");
                proxy.UpdateInfo("003", "新的姓名003");

                Console.WriteLine("所有员工列表：");
                allEmployees = proxy.GetAll();
                Array.ForEach(allEmployees.ToArray(), employee => Console.WriteLine(employee.ToString()));
                
                Console.WriteLine("\n删除员工（003）信息：");
                proxy.Delete("003");
                Console.WriteLine("所有员工列表：");
                allEmployees = proxy.GetAll();
                Array.ForEach(allEmployees.ToArray(), employee => Console.WriteLine(employee.ToString()));

            }
        }

        // DONOT WORK
        static void CallByReference()
        {
            using (var client = new WCF.REST.Client.EmpServices.EmployeesClient())
            {
                Console.WriteLine("所有员工列表：");
                var allEmployees = client.GetAll();
                Array.ForEach(allEmployees, employee => Console.WriteLine(employee.ToString()));


                Console.WriteLine("\n添加一个新员工（003）：");
                client.Create(new WCF.REST.Services.Employee
                {
                    Id = "003",
                    Name = "王五",
                    Grade = "G9",
                    Department = "行政部"
                });

                Console.WriteLine("所有员工列表：");
                allEmployees = client.GetAll();
                Array.ForEach(allEmployees, employee => Console.WriteLine(employee.ToString()));

                Console.WriteLine("\n修改员工（003）信息：");
                client.Update(new WCF.REST.Services.Employee
                {
                    Id = "003",
                    Name = "王五",
                    Grade = "G11",
                    Department = "销售部"
                });

                Console.WriteLine("所有员工列表：");
                allEmployees = client.GetAll();
                Array.ForEach(allEmployees, employee => Console.WriteLine(employee.ToString()));

                Console.WriteLine("\n删除员工（003）信息：");
                client.Delete("003");
                Console.WriteLine("所有员工列表：");
                allEmployees = client.GetAll();
                Array.ForEach(allEmployees, employee => Console.WriteLine(employee.ToString()));

            }
        }

        static void CallByWeb()
        {
            string contentType = "application/json";
            Console.WriteLine("Content-Type = N/A; Accept = N/A:");
            GetAllEmployeesByWeb("", "");
            Console.WriteLine();

            Console.WriteLine("Content-Type = application/json; Accept = N/A:");
            GetAllEmployeesByWeb(contentType, "");
            Console.WriteLine();

            Console.WriteLine("Content-Type = N/A, Accept = application/json:");
            GetAllEmployeesByWeb("", contentType);
        }

        static void GetAllEmployeesByWeb(string contentType, string accept)
        {
            // Test for
            // <webHttp automaticFormatSelectionEnabled="true"/>
            var webClient = new WebClient();

            if (!string.IsNullOrEmpty(contentType))
                webClient.Headers.Add("Content-Type", contentType);

            if (!string.IsNullOrEmpty(accept))
                webClient.Headers.Add("Accept", accept);

            using(var reader = new StreamReader(webClient.OpenRead("http://localhost:8733/services/employees/all")))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
