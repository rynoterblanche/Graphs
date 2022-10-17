namespace Graphs.Core.Entities;

public class Vertex<T>
{
    public Vertex(T data)
    {
        Value = data;
        Children = new List<Vertex<T>>();
        Parents = new List<Vertex<T>>();
    }

    public T Value { get; set; }
    public List<Vertex<T>> Children { get; set; }
    public List<Vertex<T>> Parents { get; set; }
}