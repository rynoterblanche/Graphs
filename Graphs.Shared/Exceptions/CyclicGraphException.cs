using Graphs.Core.Entities;

namespace Graphs.Shared.Exceptions;

public class CyclicGraphException<T> : Exception
{
    public List<Edge<T>> LeftOverEdges { get; }

    public CyclicGraphException(List<Edge<T>> leftOverEdges)
    {
        LeftOverEdges = leftOverEdges;
    }

    public CyclicGraphException(string message, List<Edge<T>> leftOverEdges)
        : base(message)
    {
        LeftOverEdges = leftOverEdges;
    }

    public CyclicGraphException(string message, Exception inner, List<Edge<T>> leftOverEdges)
        : base(message, inner)
    {
        LeftOverEdges = leftOverEdges;
    }
}