using System;
using System.ServiceModel;

namespace WCF.Exception.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Calculator)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("Calculator (Exception) is started...");
                };
                host.Open();

                Console.ReadLine();
            }
        }
    }
}
