using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            var watch = Stopwatch.StartNew();
            //MyMethod(1);
            //MyMethod(2);
            //var thread1 = new Thread(()=> MyMethod(1, 4));
            //thread1.Start();
            //var thread2 = new Thread(() => MyMethod(2, 3));
            //thread2.Start();
            //thread1.Join();
            //thread2.Join();

            var task1 = Task.Run(() => MyMethod(1, 4));
            var task2 = Task.Run(() => MyMethod(2, 3));
            Task.WaitAll(task1, task2);
            //Task.Factory.StartNew(() => { });
            watch.Stop();
            Console.WriteLine($"Finished: {watch.ToString()}");
        }


        static void MyMethod(int id, int waitTime )
        {
            Console.WriteLine($"Method {id} started");

            //TODO
            Thread.Sleep(TimeSpan.FromSeconds(waitTime));


            Console.WriteLine($"Method {id} finsihed");
        }
    }
}
