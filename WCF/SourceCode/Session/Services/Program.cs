using System;
using System.ServiceModel;

namespace WCF.Session.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Calculator)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("Calculator服务已经启动...");
                };
                host.Open();
                var timer = new System.Threading.Timer(delegate { GC.Collect(); }, null, 0, 100);
                Console.ReadLine();
            }
        }
    }
}
