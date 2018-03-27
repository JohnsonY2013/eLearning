using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCF.Base.Contracts;
using WCF.Base.Services;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            HostCalculatorServiceByCode();
        }

        private static void HostCalculatorServiceByCode()
        {
            using (var host = new ServiceHost(typeof(CalculatorService)))
            {
                // 添加终节点
                // 采用WSHttpBinding
                // 指定服务契约的类型ICalculator
                host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "http://127.0.0.1:9999/calculatorservice");

                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    var behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/calculatorservice/metadata");
                    host.Description.Behaviors.Add(behavior);
                }

                host.Opened += delegate
                {
                    Console.WriteLine("CalculatorService已经启动， 按任意键终止服务！");
                };

                host.Open();
                Console.Read();
            }
        }

        private static void HostCalculatorServiceViaCode()
        {
            var httpBaseAddress = new Uri("http://127.0.0.1:9999/calculatorservice");
            var tcpBaseAddress = new Uri("net.tcp://127.0.0.1:8888/calculatorservice");

            using (var host = new ServiceHost(typeof(CalculatorService), httpBaseAddress, tcpBaseAddress))
            {
                var httpBinding = new BasicHttpBinding();
                var tcpBinding = new NetTcpBinding();

                host.AddServiceEndpoint(typeof(ICalculator), httpBinding, string.Empty);
                host.AddServiceEndpoint(typeof(ICalculator), tcpBinding, string.Empty);

                var behavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (behavior == null)
                {
                    behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    host.Description.Behaviors.Add(behavior);
                }
                else
                {
                    behavior.HttpGetEnabled = true;
                }

                host.Opened += delegate
                {
                    Console.WriteLine("CalculatorService[2]已经启动， 按任意键终止服务！");
                };

                host.Open();

                Console.ReadLine();
            }
        }

        private static void HostCalculatorServiceViaConfiguration()
        {
            using (var host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("CalculatorService[2]已经启动， 按任意键终止服务！");
                };

                host.Open();

                Console.ReadLine();
            }
        }
    }
}
