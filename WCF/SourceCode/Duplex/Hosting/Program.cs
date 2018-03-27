using System;
using System.ServiceModel;
using WCF.Duplex.Services;

namespace WCF.Duplex.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Calculator)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("Service is started...");
                };

                host.Closed += delegate
                {
                    Console.WriteLine("Service is closed!");
                };

                host.Open();
                Console.ReadLine();
            }
        }
    }
}
