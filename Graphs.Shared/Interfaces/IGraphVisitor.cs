using Graphs.Core;

namespace Graphs.Shared.Interfaces;

public interface IGraphVisitor<T>
{
    void Visit(GraphNode<T> nextNode);
}