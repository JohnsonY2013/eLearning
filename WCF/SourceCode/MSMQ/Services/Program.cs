using System;
using System.Messaging;
using System.ServiceModel;
using WCF.MSMQ.Models;

namespace WCF.MSMQ.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var path = @".\private$\orders";
                if (!MessageQueue.Exists(path))
                {
                    MessageQueue.Create(path, true);
                }

                using (var host = new ServiceHost(typeof(OrderProcessor)))
                {
                    host.Opened += delegate
                    {
                        Console.WriteLine("Service is started...\n\n");
                    };
                    host.Open();

                    Console.ReadLine();
                }
            }
            catch (Exception ex) { }
        }
    }
}
