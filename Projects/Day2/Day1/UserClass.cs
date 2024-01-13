using System;

namespace ClassNamespace
{
    public class UserClass
    {
        internal readonly int ID;
        internal readonly string Name;
        public string Name2 { get; }

        private string _lastName;
        public string LastName
        {
            get
            {
                return string.IsNullOrEmpty(_lastName) ? "Majidov" : _lastName;
            }
            private set
            {
                if (value.StartsWith("M") == true)
                    _lastName = value;
            }
        }

        public UserClass()
        {
            ID = 0; 
            LastName = "asdasdasdasd";
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
