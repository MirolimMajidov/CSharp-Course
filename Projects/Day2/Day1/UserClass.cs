using System;

namespace ClassNamespace
{
    internal class UserClass
    {
        public readonly string Name;
        public string Name2 { get; }

        private string _lastName;
        public string LastName
        {
            get
            {
                return string.IsNullOrEmpty(_lastName) ? "Majidov" : _lastName;
            }
            set
            {
                if (value.StartsWith("M") == true)
                    _lastName = value;
            }
        }

        public UserClass()
        {
        }

        public UserClass(string name)
        {
            Name = name;
            Name2 = name;
        }

        public UserClass(string name, string lastName) : this(name)
        {
            LastName = lastName;
        }

        public void DoWork()
        {
            Console.WriteLine($"{Name} did work");
        }

        public static void PrintHello(string message)
        {
            Console.WriteLine(message);
        }


        ~UserClass()
        {
            LastName = null;
        }
    }

}
