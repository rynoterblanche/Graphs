using System.Collections;
using Graphs.Core.Interfaces;

namespace Graphs.Core.Entities;

public class Graph<T> : IEnumerable<Vertex<T>>
{
    private readonly VertexList<T> _vertices;
    private readonly EdgeList<T> _edges;

    public Graph()
    {
        _vertices = new VertexList<T>();
        _edges = new EdgeList<T>();
    }

    public Graph(VertexList<T> vertices)
    {
        _vertices = vertices;
        _edges = new EdgeList<T>();
    }

    public Graph(VertexList<T> vertices, EdgeList<T> edges)
    {
        _vertices = vertices;
        _edges = edges;
    }

    public EdgeList<T> Edges => _edges;

    public void AddVertex(Vertex<T> vertex)
    {
        if (!_vertices.Contains(vertex))
            _vertices.Add(vertex);
    }

    public void AddDirectedEdge(Vertex<T> from, Vertex<T> to)
    {
        if (Edges.Any(edge => edge.FromVertex == from && edge.ToVertex == to))
            return;

        from.Children.Add(to);
        to.Parents.Add(from);

        var newEdge = new Edge<T>(from, to);
        _edges.Add(newEdge);
    }

    public IEnumerator<Vertex<T>> GetEnumerator()
    {
        return _vertices.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public List<Vertex<T>> Sort(IGraphSorter<T> sorter)
    {
        return sorter.Sort(this);
    }
}
