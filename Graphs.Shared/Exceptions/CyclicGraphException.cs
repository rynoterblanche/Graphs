using Graphs.Core;

namespace Graphs.Shared.Exceptions;

public class CyclicGraphException<T> : Exception
{
    public List<GraphEdge<T>> LeftOverEdges { get; }

    public CyclicGraphException(List<GraphEdge<T>> leftOverEdges)
    {
        LeftOverEdges = leftOverEdges;
    }

    public CyclicGraphException(string message, List<GraphEdge<T>> leftOverEdges)
        : base(message)
    {
        LeftOverEdges = leftOverEdges;
    }

    public CyclicGraphException(string message, Exception inner, List<GraphEdge<T>> leftOverEdges)
        : base(message, inner)
    {
        LeftOverEdges = leftOverEdges;
    }
}