using System;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example();

            Example2();
            var result = Console.ReadLine();
            Console.WriteLine("You typed: " + result);
        }

        /// <summary>
        /// 异步执行Task
        /// </summary>
        static async void Example()
        {
            Console.WriteLine($"{DateTime.Now} Example started.");
            int t = await Task.Run(() => Allocate());
            Console.WriteLine($"{DateTime.Now}+ Example ended.");
            Console.WriteLine(t);
        }

        /// <summary>
        /// 同步执行Task
        /// </summary>
        static void Example2()
        {
            Task<int> task = new Task<int>(() =>
            {
                return Allocate();
            });
            task.Start();
            Console.WriteLine($"{DateTime.Now} Example 2 started.");
            task.Wait();
            Console.WriteLine($"{DateTime.Now} Example 2 ended.");
            Console.WriteLine(task.Result);
        }

        static int Allocate()
        {
            int size = 0;
            for (int z = 0; z < 100; z++)
            {
                for (int i = 0; i < 1000000; i++)
                {
                    var val = i.ToString();
                    if (val == null)
                        return 0;
                    size += val.Length;
                }
            }
            return size;
        }
    }
}
