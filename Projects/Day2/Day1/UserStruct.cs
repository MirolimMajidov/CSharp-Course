namespace StructNamespace
{
    internal struct UserStruct
    {
        public string Name { get; set; }
        public int Age { get; set; }

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

        public UserStruct()
        {
        }

        public UserStruct(string name)
        {
            Name = name;
        }

        public UserStruct(string name, string lastName) : this(name)
        {
            LastName = lastName;
        }
    }

}
