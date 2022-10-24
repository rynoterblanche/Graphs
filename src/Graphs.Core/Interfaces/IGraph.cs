using Graphs.Core.Entities;

namespace Graphs.Core.Interfaces;

public interface IGraph<T>: IEnumerable<Vertex<T>>
{
    void AddEdge(Vertex<T> from, Vertex<T> to);
}