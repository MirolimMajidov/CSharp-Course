namespace SOLID.DIP
{
    // Bad example
    public class WorkerServiceBad
    {
        private readonly FileLogger _logger;

        public WorkerServiceBad()
        {
            _logger = new FileLogger();
        }

        public void DoWork()
        {
            _logger.Log("Doing work");
        }
    }

    // Good example
    public interface ILogger
    {
        void Log(string message);
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class DBLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class WorkerService
    {
        private readonly ILogger _logger;

        public WorkerService(ILogger logger)
        {
            _logger = logger;
        }

        public void DoWork()
        {
            _logger.Log("Doing work");
        }
    }


}
