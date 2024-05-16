public interface ILogger
{
    void Log(string message);
}

public class Calculator
{
    private readonly ILogger _logger;

    public Calculator(ILogger logger)
    {
        _logger = logger;
    }

    public int Add(int a, int b)
    {
        _logger.Log($"Adding {a} and {b}");
        _logger.Log($"Adding {a} and {b}");
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        _logger.Log($"Subtracting {b} from {a}");
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        _logger.Log($"Multiplying {a} and {b}");
        return a * b;
    }

    public double Divide(int a, int b)
    {
        if (b == 0)
        {
            _logger.Log("Attempted to divide by zero");
            throw new ArgumentException("Cannot divide by zero.");
        }

        _logger.Log($"Dividing {a} by {b}");
        return (double)a / b;
    }
}
