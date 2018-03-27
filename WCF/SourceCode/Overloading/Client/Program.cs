using System;

namespace WCF.Overloading.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin to invocate generated proxy");
            InvocateGeneratedProxy();

            Console.WriteLine("Begin to invocate revised proxy");
            InvocateRevisedProxy();
        }

        static void InvocateGeneratedProxy()
        {
            using (var client = new CalculatorService.CalculatorClient())
            {
                var result = client.AddWithTwoOperands(1, 2);
                Console.WriteLine($"x + y = {result} when x = 1 and y = 2");

                result = client.AddWithThreeOperands(1, 2, 3);
                Console.WriteLine($"x + y + z = {result} when x = 1 and y = 2 and z = 3");
            }
        }

        static void InvocateRevisedProxy()
        {
            using (var client = new MyCalculatorClient())
            {
                var result = client.Add(1, 2);
                Console.WriteLine($"x + y = {result} when x = 1 and y = 2");

                result = client.Add(1, 2, 3);
                Console.WriteLine($"x + y + z = {result} when x = 1 and y = 2 and z = 3");
            }
        }
    }
}
