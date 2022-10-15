using Graphs.Core.Entities;

namespace Graphs.Core.Interfaces;

public interface IGraphVisitor<T>
{
    void Visit(Vertex<T> nextVertex);
}