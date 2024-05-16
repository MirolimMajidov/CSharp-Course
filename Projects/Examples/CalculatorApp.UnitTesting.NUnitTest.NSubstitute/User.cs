using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.UnitTesting.NUnitTest.NSubstitute
{
    public class User
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
