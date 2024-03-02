using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Program
    {
        //stateless and stateful
        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            var watch = Stopwatch.StartNew();
            SemaphoreTest();


            //using var timeoutCancellationTokenSource = new CancellationTokenSource();
            //timeoutCancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            //var cancellationToken = timeoutCancellationTokenSource.Token;

            //Task task4 = Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(1000);
            //        if (cancellationToken.IsCancellationRequested)
            //        {
            //            break;
            //        }
            //        //cancellationToken.ThrowIfCancellationRequested();
            //        Console.WriteLine($"Working...");
            //        Task.Delay(1000, cancellationToken);
            //    }

            //}, cancellationToken).ContinueWith(task => Console.WriteLine("Hello Task!"));

            //try
            //{
            //    //task4.Wait();
            //    timeoutCancellationTokenSource.Cancel();
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Task canceled.");
            //}


            //Parallel.For(1, 5, Square);

            //ParallelLoopResult result = Parallel.ForEach<int>(
            //       new List<int>() { 1, 3, 5, 8 },
            //       Square
            //);

            //void Square(int n)
            //{
            //    Console.WriteLine($"Completed task: {Task.CurrentId}");
            //    Console.WriteLine($"Result of {n} is {n * n}");
            //    Thread.Sleep(TimeSpan.FromSeconds(0.5));
            //}

            //int n1 = 4, n2 = 5;
            //Task<int> sumTask1 = new Task<int>(() => Sum(n1, n2));
            //Task<int> sumTask2 = new Task<int>(() => Sum(n1, n2));
            //Task sumTask3 = new Task(() => Sum(n1, n2));
            //sumTask1.Start();
            //sumTask2.Start();
            //sumTask3.Start();

            //Thread.Sleep(TimeSpan.FromSeconds(1));
            //int result = sumTask1.Result;//Not recomended
            //result = sumTask2.GetAwaiter().GetResult();
            //sumTask3.Wait();
            //Console.WriteLine($"{n1} + {n2} = {result}"); // 4 + 5 = 9

            //int Sum(int a, int b) => a + b;

            //MyMethod(1, 3);
            //MyMethod(2, 2);
            //var thread1 = new Thread(() => MyMethod(1, 3));
            //thread1.Start();
            //var thread2 = new Thread(() => MyMethod(2, 2));
            //thread2.Start();
            //thread1.Join();
            //thread2.Join();

            //var task = new Task(() => MyMethod(0, 1));
            //task.Start();
            //var task1 = Task.Run(() => MyMethod(1, 3));
            //var task2 = Task.Run(() => MyMethod(2, 2)).ContinueWith(task=> Message());
            ////task2.ConfigureAwait(false);
            //Task.WaitAll(task, task1, task2);

            //var outer = Task.Factory.StartNew(() => 
            //{

            //}, TaskCreationOptions.LongRunning);
            watch.Stop();
            Console.WriteLine($"Finished: {watch.ToString()}");
        }


        static void MyMethod(int id, int waitTime)
        {
            Console.WriteLine($"Method {id} started");

            //TODO
            Thread.Sleep(TimeSpan.FromSeconds(waitTime));


            Console.WriteLine($"Method {id} finsihed");
        }

        static void Message()
        {
            Console.WriteLine($"Done");
        }

        private static Semaphore _pool = new Semaphore(initialCount: 0, maximumCount: 3);

        public static void SemaphoreTest()
        {
            for (int i = 1; i <= 6; i++)
            {
                Thread t = new Thread(Worker);
                t.Start(i);
            }

            Thread.Sleep(500);

            Console.WriteLine("Main thread calls Release(3).");
            _pool.Release(releaseCount: 3);

            Console.WriteLine("Main thread exits.");
        }

        private static void Worker(object num)
        {
            Console.WriteLine("Thread {0} begins and waits for the semaphore.", num);
            _pool.WaitOne();

            Console.WriteLine("Thread {0} enters the semaphore.", num);

            Thread.Sleep(1000);

            Console.WriteLine("Thread {0} releases the semaphore.", num);
            Console.WriteLine("Thread {0} previous semaphore count: {1}", num, _pool.Release());
        }
    }
}
