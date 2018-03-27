using System;
using System.ServiceModel;
using WCF.Base.Client.CalculatorServices;
using WCF.Base.Contracts;

namespace WCF.Base.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // 调用控制台寄宿
            using (var proxy = new CalculatorServiceClient())
            {
                Console.WriteLine($"x + y = { proxy.Add(4, 2)} when x = 4 and y = 2");
                Console.WriteLine($"x - y = { proxy.Subtract(4, 2)} when x = 4 and y = 2");
                Console.WriteLine($"x * y = { proxy.Multiply(4, 2)} when x = 4 and y = 2");
                Console.WriteLine($"x / y = { proxy.Divide(4, 2)} when x = 4 and y = 2");
                Console.WriteLine();
            }

            // 由于服务端和客户端都是在同一个解决方案中，完全可以让服务端和客户端引用相同的契约
            using (var channelFactory = new ChannelFactory<ICalculator>(new WSHttpBinding(), "http://127.0.0.1:9999/calculatorservice"))
            {
                ICalculator proxy = channelFactory.CreateChannel();
                using (proxy as IDisposable)
                {
                    Console.WriteLine($"x + y = { proxy.Add(4, 2)} when x = 4 and y = 2");
                    Console.WriteLine($"x - y = { proxy.Subtract(4, 2)} when x = 4 and y = 2");
                    Console.WriteLine($"x * y = { proxy.Multiply(4, 2)} when x = 4 and y = 2");
                    Console.WriteLine($"x / y = { proxy.Divide(4, 2)} when x = 4 and y = 2");
                    Console.WriteLine();
                }
            }

            // 调用IIS寄宿
            using (var proxy = new CalculatorServicesWeb.CalculatorClient())
            {
                Console.WriteLine($"x + y = { proxy.Add(4, 2)} when x = 4 and y = 2");
                Console.WriteLine($"x - y = { proxy.Subtract(4, 2)} when x = 4 and y = 2");
                Console.WriteLine($"x * y = { proxy.Multiply(4, 2)} when x = 4 and y = 2");
                Console.WriteLine($"x / y = { proxy.Divide(4, 2)} when x = 4 and y = 2");
                Console.WriteLine();
            }
        }
    }
}
