using System;
using System.ServiceModel;
using WCF.Duplex.Services;

namespace WCF.Duplex.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpDuplexComm();

            //HttpDuplexComm();
        }

        static void TcpDuplexComm()
        {
            var instanceContext = new InstanceContext(new CalculatorCallback());
            using (var channelFactory = new DuplexChannelFactory<ICalculator>(instanceContext, "CalculatorService"))
            {
                var proxy = channelFactory.CreateChannel();
                using (proxy as IDisposable)
                {
                    proxy.Add(1, 2);
                    Console.ReadLine();
                }
            }
        }

        static void HttpDuplexComm()
        {
            var instanceContext = new InstanceContext(new CalculatorHttpCallback());
            using (var proxy = new CalculatorServiceWeb.CalculatorServiceClient(instanceContext))
            {
                proxy.Add(1, 2);
                Console.ReadLine();
            }
        }
    }

    class CalculatorCallback : ICallback
    {
        public void DisplayResult(double x, double y, double result)
        {
            Console.WriteLine($"x + y = {result} when x = {x} and y = {y}");
        }
    }

    class CalculatorHttpCallback : CalculatorServiceWeb.CalculatorServiceCallback
    {
        public void DisplayResult(double x, double y, double result)
        {
            Console.WriteLine($"x + y = {result} when x = {x} and y = {y}");
        }
    }
}
