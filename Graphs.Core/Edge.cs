namespace Graphs.Core;

public class Edge<T>
{
    public Vertex<T> FromVertex { get; }
    public Vertex<T> ToVertex { get; }

    public Edge(Vertex<T> fromVertex, Vertex<T> toVertex)
    {
        FromVertex = fromVertex;
        ToVertex = toVertex;
    }
}