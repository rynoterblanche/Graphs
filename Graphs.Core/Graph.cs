using System.Collections;

namespace Graphs.Core;

public class Graph<T>: IEnumerable<GraphNode<T>>
{
    private readonly NodeList<T> _nodes;
    public readonly List<GraphEdge<T>> Edges;

    public Graph()
    {
        _nodes = new NodeList<T>();
        Edges = new List<GraphEdge<T>>();
    }

    public Graph(NodeList<T> nodes)
    {
        _nodes = nodes;
        Edges = new List<GraphEdge<T>>();
    }

    public Graph(NodeList<T> nodes, List<GraphEdge<T>> edges)
    {
        _nodes = nodes;
        Edges = edges;
    }

    public void AddNode(GraphNode<T> node)
    {
        if (!_nodes.Contains(node))
            _nodes.Add(node);
    }

    public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to)
    {
        if (from.Neighbors.Contains(to))
            return;

        from.Neighbors.Add(to);

        var newEdge = new GraphEdge<T>(from, to);
        Edges.Add(newEdge);
    }

    public IEnumerator<GraphNode<T>> GetEnumerator()
    {
        return _nodes.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}