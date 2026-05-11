using Microsoft.JSInterop;

namespace task1.server.Services;

public class JsInteropService
{
    [JSInvokable]
    public static string GetCurrentTime()
    {
        return DateTime.Now.ToString("HH:mm:ss");
    }
}