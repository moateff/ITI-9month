using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Diagnostics;
using System.Text.Json;

namespace task1.Aspects;

[PSerializable]
public class LoggingAspect : OnMethodBoundaryAspect
{
    private Stopwatch? _sw;

    public override void OnEntry(MethodExecutionArgs args)
    {
        _sw = Stopwatch.StartNew();

        Console.WriteLine(
            $"Parameters: {JsonSerializer.Serialize(args.Arguments)}");
    }

    public override void OnSuccess(MethodExecutionArgs args)
    {
        Console.WriteLine(
            $"Return Value: {args.ReturnValue}");
    }

    public override void OnExit(MethodExecutionArgs args)
    {
        _sw?.Stop();

        Console.WriteLine(
            $"Execution Time: {_sw?.ElapsedMilliseconds} ms");
    }
}