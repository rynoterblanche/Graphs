using Graphs.Core.Interfaces;
using Graphs.Shared.Interfaces;

namespace Graphs.Infrastructure.Printers;

public class AdjacencyListPrinter<T> : IGraphPrinter<T>
{
    private readonly ILogger _logger;

    public AdjacencyListPrinter(ILogger logger)
    {
        _logger = logger;
    }
    
    public void Print(IGraph<T> graph)
    {
        foreach (var vertex in graph)
        {
            var childValues = vertex.Children.Select(v => v.Value);
            _logger.Log($"{vertex.Value} -> {string.Join(",", childValues)}");
        }
    }
}