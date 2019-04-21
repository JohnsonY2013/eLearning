using System;
using System.Threading;

namespace MultiThreadsDemo
{
    public class Mission
    {
        // 9s
        public static void Run()
        {
            var result = 0;

            for (int i = 1; i < 5000; i++)
            {
                for (int j = 1; j < 10000; j++)
                {
                    //Console.WriteLine($"i/j : {i}/{j}");
                    var temp = i.ToString().Length + j.ToString().Length;
                    result += (i + j) / temp;
                }
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + result);

        }

        public static void Run2(object obj)
        {
            var result = 0;

            for (int i = 1; i < 5000; i++)
            {
                for (int j = 1; j < 10000; j++)
                {
                    //Console.WriteLine($"i/j : {i}/{j}");
                    var temp = i.ToString().Length + j.ToString().Length;
                    result += (i + j) / temp;
                }
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + result);

        }
    }
}
