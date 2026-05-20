namespace OrderSystem;

public class ConsoleOrderLogger : IOrderLogger
{ 
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] { message }");
    }
}