using Graphs.Core;

namespace Graphs.Shared.UnitTests;

public class GraphBuilder<T>
{
    private readonly Graph<T> _graph = new();

    public GraphBuilder<T> WithEdge(T fromValue, T toValue)
    {
        var fromNode = _graph.FirstOrDefault(node => node.Value.Equals(fromValue));
        if (fromNode == null)
        {
            fromNode = new GraphNode<T>(fromValue);
            _graph.AddNode(fromNode);
        }

        var toNode = _graph.FirstOrDefault(node => node.Value.Equals(toValue));
        if (toNode == null)
        {
            toNode = new GraphNode<T>(toValue);
            _graph.AddNode(toNode);
        }

        _graph.AddDirectedEdge(fromNode, toNode);

        return this;
    }

    public Graph<T> Build() => _graph;

}