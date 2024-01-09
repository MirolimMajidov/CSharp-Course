using ClassNamespace;

namespace Day2;

internal class Program
{
    public static void Main(string[] args)
    {
        var user = new UserClass("Mirolim");
        var user2 = new UserRecord("Mirolim");
        var user3 = new UserStruct("Mirolim");

        user.DoWork();

        UserClass.PrintHello("Salom");
    }
}
