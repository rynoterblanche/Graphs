namespace Graphs.Shared.Exceptions;

public class CyclicGraphException<T> : Exception
{

    public CyclicGraphException() : base() { }

    public CyclicGraphException(string message) : base(message) { }

    public CyclicGraphException(string message, Exception inner) : base(message, inner) { }
}