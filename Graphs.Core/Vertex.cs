namespace Graphs.Core;

public class Vertex<T>
{
    public Vertex(T data)
    {
        Value = data;
    }

    public T Value { get; set; }
}