namespace SOLID.ISP
{
    // Bad example
    public interface IAnimalBad
    {
        void Fly();
        void Eat();
        void Walk();
        void Run();
    }

    public class BirdBad : IAnimalBad
    {
        public void Eat()
        {
            Console.WriteLine("Eating");
        }

        public virtual void Fly()
        {
            Console.WriteLine("Flying");
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }

    public class CatBad : IAnimalBad
    {
        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            throw new InvalidOperationException("Cat cannot fly");
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }

    // Good example

    public interface IAnimal
    {

    }

    public interface ICanFly : IAnimal
    {
        void Fly();
    }

    public interface ICanRun : IAnimal
    {
        void Run();
    }

    public interface ICanEat : IAnimal
    {
        void Eat();
    }

    public class Bird : ICanFly, ICanRun, ICanEat
    {
        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            Console.WriteLine("Flying");
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }

    public class Cat : ICanRun, ICanEat
    {
        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
