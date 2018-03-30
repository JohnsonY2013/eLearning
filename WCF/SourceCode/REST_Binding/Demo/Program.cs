using System;
using System.ServiceModel;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (WebHttpSecurityMode item in Enum.GetValues(typeof(WebHttpSecurityMode)))
            {
                var binding = new WebHttpBinding(item);
                ListBindingElements(binding);
            }
        }

        static void ListBindingElements(WebHttpBinding binding)
        {
            var index = 1;
            Console.WriteLine(binding.Security.Mode + ":");
            foreach(var element in binding.CreateBindingElements())
            {
                Console.WriteLine($"{index++}. {element.GetType().FullName}");
            }
            Console.WriteLine();
        }
    }
}
