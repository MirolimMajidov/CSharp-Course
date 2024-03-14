namespace SOLID.LSP
{
    // Bad example
    public class BirdBad
    {
        public virtual void Fly()
        {
            Console.WriteLine("Flying");
        }

        public virtual void Run()
        {
            Console.WriteLine("Runing");
        }
    }

    public class OwlBad : Bird
    {
    }

    public class OstrichBad : BirdBad
    {
        public override void Fly()
        {
            throw new InvalidOperationException("Ostriches can't fly");
        }
    }

    // Good example
    public interface IFlyable
    {
        void Fly();
    }

    public class Bird
    {
        public virtual void Run()
        {
            Console.WriteLine("Runing");
        }
    }

    public class Owl : Bird, IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flying");
        }
    }

    public class Ostrich : Bird
    {
    }

    public class Test()
    {
        void TestMethod(Bird bird)
        {
            bird.Run();
        }

        void TestMethod2()
        {
            var owl = new Owl();
            var ostrich = new Ostrich();
            TestMethod(owl);
            TestMethod(ostrich);
        }
    }
}
