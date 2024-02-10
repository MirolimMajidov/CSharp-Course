using System.Collections.Concurrent;
using System.Collections;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsAndLINQQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array: ");

            var items = new List<User>
            {
                new User(){Name = "Sanjar", Age = 10 },
                new User(){Name = "Doston", Age = 30 },
                new User(){Name = "Jake", Age = 50 },
                new User(){Name = "Alisher", Age = 5 },
                new User(){Name = "Ahmat", Age = 20 },
            };

            Console.WriteLine("Result: ");
            Print(items.Where(i => i.Age > 10 && i.Name.ToLower().StartsWith("a")).Select(i => i.Name));


            //var item = items.FirstOrDefault(i => i);
            //Console.WriteLine(item);
            //Print(items);

            //Console.WriteLine("Result1: ");
            //var _items = items.Where(i => i > 10);
            //Print(_items);

            //Console.WriteLine("Result2: ");
            //items.Add(40);
            //Print(_items);

            //Console.WriteLine("Result3: ");
            //items.Add(60);
            //items.Add(10);
            //Print(_items);

            void Print(IEnumerable<object> items)
            {
                foreach (var item in items)
                    Console.WriteLine(item);
            }

            //Console.WriteLine("List: ");
            //var item2 = new List<int>() { 1, 20 };
            //item2.Add(4);
            //item2.Add(2);
            //foreach (var item in item2)
            //    Console.WriteLine(item);

            //Console.WriteLine("Dictionary: ");
            //var item3 = new Dictionary<int, string>() {
            //    { 80, "Nabijon" },
            //    { 100, "Rahmatullo" }
            //};
            //item3.Add(199, "Naimjon");
            //item3.Remove(199);

            //foreach (var (mykey, myvalue) in item3)
            //    Console.WriteLine($"Key: {mykey}, Value: {myvalue}");

            //Console.WriteLine("ConcurrentDictionary: ");
            //var item4 = new ConcurrentDictionary<int, string>();
            //item4.TryAdd(199, "Naimjon");

            //foreach (var item in item4)
            //    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");

            //Console.WriteLine("List: ");
            //var item2 = new int[]{ 1, 20 };
            //Span<int> item3 = new int[] { 12, 10 };
            //item3 = item2.AsSpan();
            //foreach (var item in item3)
            //    Console.WriteLine(item);

            //Queue<string> queues = new Queue<string>();
            //queues.Enqueue("a");
            //queues.Enqueue("b");
            //queues.Enqueue("c");
            //foreach (var item in queues)
            //    Console.WriteLine(item);
            //var _item1 = queues.Dequeue();
            //var _item2 = queues.Dequeue();

            //Stack<string> queues = new Stack<string>();
            //queues.Push("a");
            //queues.Push("b");
            //queues.Push("c");

            //Console.WriteLine("foreach: ");
            //foreach (var item in queues)
            //    Console.WriteLine(item);

            //Console.WriteLine("GetValue: ");
            //Console.WriteLine(queues.Peek());
            //Console.WriteLine(queues.Pop());
            //Console.WriteLine(queues.Pop());

            //Console.WriteLine("List: ");
            //var item2 = new HashSet<int>() { 1, 20 };
            //item2.Add(4);
            //item2.Add(2);
            //foreach (var item in item2)
            //    Console.WriteLine(item);


            //var item2 = new MyList<int>(1, 2, 3);
            //foreach (var item in item2)
            //    Console.WriteLine(item);

        }

        class MyList<T> : IEnumerable
        {
            public T[] _items;

            public MyList(params T[] items)
            {
                _items = items;
            }

            public IEnumerator GetEnumerator()
            {
                foreach (var item in _items)
                    yield return item;
            }
        }

        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
