namespace Graphs.Core.Entities;

public interface IGraph<T>: IEnumerable<Vertex<T>>
{
    void AddEdge(Vertex<T> from, Vertex<T> to);
}