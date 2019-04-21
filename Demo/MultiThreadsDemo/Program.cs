using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingleTest();       //9.29s
            //ThreadTest();     // 10 t => 95s / 26s
            //ThreadPoolTest();   // 10 t 26s
            //TaskTest2();             // 29s
            //ParallelTest();             // 29s
            ParallelForTest();              //22s

            Console.ReadLine();
        }

        static int Sum(int n)
        {
            if (n < 0) return 0;
            if (n == 0 || n == 1) return n;

            return n + Sum(n - 1);
        }

        static void SingleTest()
        {
            Console.WriteLine("Main thread: " + Thread.CurrentThread.ManagedThreadId);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            Mission.Run();

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            var ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
        }

        static void ThreadTest()
        {
            Console.WriteLine("Main thread: " + Thread.CurrentThread.ManagedThreadId);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var threadArray = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threadArray[i] = new Thread(Mission.Run);
                threadArray[i].Start();
            }

            foreach (var thread in threadArray)
            {
                //thread.Start();
                thread.Join();
            }
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            var ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
        }

        static void ThreadPoolTest()
        {
            Console.WriteLine("Main thread: " + Thread.CurrentThread.ManagedThreadId);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            ThreadPool.SetMinThreads(10, 10);
            ThreadPool.SetMaxThreads(20, 20);

            var taskCount = 10;
            var done = new AutoResetEvent(false);

            for (int i = 0; i < taskCount; i++)
            {
                ThreadPool.QueueUserWorkItem(x =>
                {
                    Mission.Run();
                    if (0 == Interlocked.Decrement(ref taskCount))
                    {
                        done.Set();
                    }
                });
            }

            done.WaitOne();

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            var ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
        }

        static void TaskTest()
        {
            Console.WriteLine("Main thread: " + Thread.CurrentThread.ManagedThreadId);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var taskCount = 10;
            var done = new AutoResetEvent(false);
            for (int i = 0; i < taskCount; i++)
            {
                var t = Task.Factory.StartNew(() =>
                {
                    Mission.Run();
                    if (0 == Interlocked.Decrement(ref taskCount))
                    {
                        done.Set();
                    }
                });
            }

            done.WaitOne();

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            var ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
        }

        static void TaskTest2()
        {
            Console.WriteLine("Main thread: " + Thread.CurrentThread.ManagedThreadId);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var taskList = new List<Task>();
            var taskCount = 10;
            for (int i = 0; i < taskCount; i++)
            {
                taskList.Add(Task.Factory.StartNew(Mission.Run));
            }
            Task.WaitAll(taskList.ToArray());

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            var ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
        }

        static void ParallelTest()
        {
            Console.WriteLine("Main thread: " + Thread.CurrentThread.ManagedThreadId);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var taskCount = 10;
            var actionsArray = new List<Action>();

            for (int i = 0; i < taskCount; i++)
            {
                actionsArray.Add(Mission.Run);
            }
            var array = actionsArray.ToArray();
            Parallel.Invoke(new ParallelOptions { MaxDegreeOfParallelism = taskCount }, array);

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            var ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
        }

        static void ParallelForTest()
        {
            Console.WriteLine("Main thread: " + Thread.CurrentThread.ManagedThreadId);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            Parallel.For(1, 10, (i) => { Mission.Run(); });

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            var ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
        }
    }
}
