using System;
using System.ServiceModel;
using WCF.Session.Services;

namespace WCF.Session.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TestByReference();

            //TestByDll();

            Console.ReadLine();
        }

        static void TestByDll()
        {
            var channelFactory = new ChannelFactory<ICalculator>("httpEndpoint");
            Console.WriteLine("Create a calculator proxy: proxy 1");
            var proxy1 = channelFactory.CreateChannel();
            Console.WriteLine("Invocate proxy1.Adds(1)");
            proxy1.Adds(1);
            Console.WriteLine("Invocate proxy1.Adds(2)");
            proxy1.Adds(2);
            Console.WriteLine($"The result return via proxy1.GetResult() is : {proxy1.GetResult()}");
            (proxy1 as ICommunicationObject).Close();

            Console.WriteLine("Create a calculator proxy: proxy 2");
            var proxy2 = channelFactory.CreateChannel();
            Console.WriteLine("Invocate proxy2.Adds(1)");
            proxy2.Adds(1);
            Console.WriteLine("Invocate proxy2.Adds(2)");
            proxy2.Adds(2);
            Console.WriteLine($"The result return via proxy2.GetResult() is : {proxy2.GetResult()}");
            (proxy2 as ICommunicationObject).Close();
        }

        static void TestByReference()
        {
            using (var client1 = new CalculatorServices.CalculatorClient())
            {
                Console.WriteLine("Create a calculator service client: client1");
                Console.WriteLine("Invocate client1.Adds(1)");
                client1.Adds(1);
                Console.WriteLine("Invocate client1.Adds(2)");
                client1.Adds(2);
                Console.WriteLine($"The result return via client1.GetResult() is : {client1.GetResult()}");
            }

            using (var client2 = new CalculatorServices.CalculatorClient())
            {
                Console.WriteLine("Create a calculator service client: client2");
                Console.WriteLine("Invocate client2.Adds(1)");
                client2.Adds(1);
                Console.WriteLine("Invocate client2.Adds(2)");
                client2.Adds(2);
                Console.WriteLine($"The result return via client2.GetResult() is : {client2.GetResult()}");
            }
        }
    }
}
