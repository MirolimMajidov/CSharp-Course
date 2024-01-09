namespace RecordNamespace
{
    internal record UserRecord
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

        public UserRecord()
        {
        }

        public UserRecord(string name)
        {
            Name = name;
        }

        public UserRecord(string name, string lastName) : this(name)
        {
            LastName = lastName;
        }
    }
}
