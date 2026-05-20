namespace OrderSystem;

public class FileOrderLogger : IOrderLogger
{ 
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] { message }");
    }
}