using Graphs.Infrastructure.Printers;
using Graphs.Shared.Interfaces;

namespace Graphs.Infrastructure.Logging;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}