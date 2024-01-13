// Declaration of delegate
using System;

delegate void Calculator(int a, int b);

class Program
{
    static void Main()
    {
        Calculator calculator = Addition;
        calculator(10, 5);//Result: 15

        //Recalling delegate
        calculator = Subtraction;
        calculator(10, 5);//Result: 5

        Console.ReadLine();

        //Methods for operations
        void Addition(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        void Subtraction(int a, int b)
        {
            Console.WriteLine(a - b);
        }
    }

    // Declaration of event
    public static event EventHandler MyEvent;

    static void Main2()
    {
        // Subscribing to the event
        MyEvent += (sender, e) => Console.WriteLine("Event triggered!");

        // Raising the event
        MyEvent?.Invoke(null, EventArgs.Empty);
    }
}