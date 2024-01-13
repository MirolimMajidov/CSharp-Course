// Action delegate example
using System;

Action<string> messagePrinter = (message) 
    => Console.WriteLine($"Action: {message}");
messagePrinter("Hello, Action!");// Output: "Action:Hello, Action"

// Func delegate example
Func<int, int, int> addFunc = (a, b) => a + b;
Console.WriteLine($"Func: {addFunc(5, 3)}"); // Output: 8
 // Declaration of event
    public static event EventHandler MyEvent;

    static void Main()
    {
        // Subscribing to the event
        MyEvent += (sender, e) => Console.WriteLine("Event triggered!");

        // Raising the event
        MyEvent?.Invoke(null, EventArgs.Empty);

        Console.ReadLine();
    }