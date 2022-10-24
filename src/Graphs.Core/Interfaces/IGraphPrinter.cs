using Graphs.Core.Entities;

namespace Graphs.Core.Interfaces;

public interface IGraphPrinter<T>
{
    void Print(IGraph<T> graph);
}