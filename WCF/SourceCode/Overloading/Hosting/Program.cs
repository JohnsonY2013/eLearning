using System;
using System.ServiceModel;
using WCF.Overloading.Services;

namespace WCF.Overloading.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            HostCalculatorServiceViaConfiguration();
        }

        private static void HostCalculatorServiceViaConfiguration()
        {
            using (var host = new ServiceHost(typeof(Calculator)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("Calculator服务已经启动， 按任意键终止服务！");
                };

                host.Open();

                Console.ReadLine();
            }
        }
    }
}
