using System;
using System.ServiceModel.Web;

namespace WCF.REST.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new WebServiceHost(typeof(WCF.REST.Services.Time)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("Service is started...");
                };
                host.Open();
                Console.WriteLine();
            }
        }
    }
}
