using Graphs.Core.Entities;

namespace Graphs.Core.Interfaces;

public interface IGraphSorter<T>
{
    List<Vertex<T>> Sort(IGraph<T> graph);
}