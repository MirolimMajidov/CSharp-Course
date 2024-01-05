using System.Diagnostics;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace Day2;

internal class Program
{
    public static void Main(string[] args)
    {
        //int i = 5;
        //for (int j = 0; j < i; j++)
        //{
        //    Console.WriteLine(j);
        //}

        //for (;;)
        //{
        //    if(!(i < 50)) break;

        //    Console.WriteLine(i);

        //    i += 5;
        //}

        //Stopwatch sw = Stopwatch.StartNew();

        //var names = new string[] { "Sardor", "Shodiyor", "Bek"};

        //foreach (var name in names)
        //{
        //    Console.WriteLine(name);
        //}

        //sw.Stop();


        //Stopwatch sw2 = Stopwatch.StartNew();

        //while (sw2.ElapsedMilliseconds < 5000)
        //{
        //    Console.WriteLine(sw2.ElapsedMilliseconds);
        //}
        //sw2.Stop();

        //Stopwatch sw3 = Stopwatch.StartNew();
        //do
        //{
        //    Console.WriteLine(sw3.ElapsedMilliseconds);
        //} while (sw3.ElapsedMilliseconds < 5000);
        //sw3.Stop();

        //PrintHello("Jake");
        //var salom = GetHello("Jake");
        //Console.WriteLine(salom);

        //var salom2 = GetHelloFromNames("Jake", "Mirolim");
        //Console.WriteLine(salom2);

        Gender gender = Gender.Male;


        if (gender == Gender.Male)
        {
            Console.WriteLine("This is a man");
        }
        if ((int)gender == 0)
        {
            Console.WriteLine("It is a male from the second condition");
        }


        var sum = Sum(5);
        Console.WriteLine(sum);

        Debugger.Launch();
        int Sum(int number)
        {
            if (number == 0) return 0;

            return number + Sum(--number);
        }
    }

    static void PrintHello(string userName = "Mirolim")
    {
        Console.WriteLine($"Salom {userName}");
    }

    static string GetHello(string userName = "Mirolim")
    {
        return $"Salom {userName}";
    }

    static string GetHelloFromNames(params string[] names)
    {
        var namesWithSalom = names.Select(n => $"Salom {n}");

        return string.Join(",", namesWithSalom);
    }


    //Enum
    Gender gender = Gender.Male;

    enum Gender { Male = 1, Female = 10, Unknown };
}

internal class MyClass
{
    void MyMethod1()
    {
        MyMethod3();
    }

    static void MyMethod2()
    {

    }

    static void MyMethod3()
    {
        MyMethod2();
    }
}