namespace Graphs.Core.Entities;

public class Vertex<T>
{

    public Vertex(T data)
    {
        Value = data;
        Neighbors = new List<Vertex<T>>();
    }

    public T Value { get; set; }
    public List<Vertex<T>> Neighbors { get; set; }
}