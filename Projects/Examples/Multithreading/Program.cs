using System.Collections.Concurrent;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Multithreading
{
    internal class Program
    {
        //stateless and stateful
        static void Main(string[] args)
        {
            //Version1
            var provider = new MyDataProvider();
            //asdjkhasdukjhasdjkhasdjkhasd
            provider.Dispose();
            provider.Dispose();

            //Version2
            using var provider2 = new MyDataProvider();


            //Version3
            using (var provider3 = new MyDataProvider())
            {

            }

            Console.WriteLine("Started");
            var watch = Stopwatch.StartNew();
            //Method();
            //Method2().GetAwaiter();
            //var result = MethodAsync().GetAwaiter().GetResult();
            //watch.Stop();
            Console.WriteLine($"Before starting task: {balance}");
            try
            {
                var mutex = new Mutex(true, "Test");
                mutex.WaitOne();

                mutex.ReleaseMutex();

                var tasks = new List<Task>();
                for (int i = 0; i < 3000; i++)
                {
                    //TransferMoney(100, i);
                    //tasks.Add(Task.Run(() => TransferMoney(100, i)));
                    tasks.Add(Task.Run(() => AddItem(i)));
                }
                for (int i = 0; i < 3000; i++)
                {
                    tasks.Add(Task.Run(() => RemoveItem(i)));
                }
                foreach (var task in tasks)
                {

                }
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {

                //throw;
            }

            Console.WriteLine($"After finishing task: {balance}");

            Console.WriteLine($"Finished: {watch.ToString()}");
        }

        static Random random = new Random();
        static int balance = 1000;
        static object lockBalance = new object();
        static void TransferMoney(int amount, int taskId)
        {
            lock (lockBalance)
            {
                if (balance >= amount)
                {
                    Console.WriteLine($"Started {taskId}, Balance: {balance}");
                    Thread.Sleep(random.Next(10));
                    balance -= amount;
                    Console.WriteLine($"Finished {taskId}, Balance: {balance}");
                }
            }
        }

        static ConcurrentDictionary<int, int> items = new ConcurrentDictionary<int, int>();
        static void AddItem(int taskId)
        {
            items.TryAdd(taskId, 0);
        }

        static void RemoveItem(int taskId)
        {
            items.Remove(taskId, out int _old);
        }

        static void Method()
        {
            for (int i = 0; i < 10; i++)
            {
                //sdasdas
            }
            Console.WriteLine("Method1");
        }

        static async void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                //sdasdas
            }
            Console.WriteLine("Method1");
            var task = MethodAsync();
            await task;
        }

        static Task Method2()
        {
            //await Task.Run(() => { Console.WriteLine("Method2"); });

            return MethodAsync();
        }

        static async Task<int> MethodAsync()
        {
            //await Task.Run(() => { Console.WriteLine("Method2"); });
            for (int i = 0; i < 10; i++)
            {
            }

            return await Task.FromResult(0);
        }

        //SemaphoreTest();
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


    public class MyDataProvider : IDisposable
    {
        SqlConnection connection;
        Program myData;

        public MyDataProvider()
        {
            connection = new SqlConnection("");
            myData = new Program();
        }

        public void Open()
        {
            //connection.Open();
        }

        public void Close()
        {
            //connection.Close();
        }

        private bool _disposedValue;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    myData = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                connection.Dispose();
                connection = null;

                _disposedValue = true;
            }
        }

        ~MyDataProvider()
        {
            Dispose(false);
        }
    }
}
