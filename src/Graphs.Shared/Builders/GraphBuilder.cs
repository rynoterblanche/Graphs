using Graphs.Core.Entities;

namespace Graphs.Shared.Builders;

public class GraphBuilder<T>
{
    private readonly Graph<T> _graph = new();

    public GraphBuilder<T> WithEdge(T fromValue, T toValue)
    {
        var fromVertex = _graph.FirstOrDefault(v => v.Value.Equals(fromValue));
        if (fromVertex == null)
        {
            fromVertex = new Vertex<T>(fromValue);
        }

        var toVertex = _graph.FirstOrDefault(v => v.Value.Equals(toValue));
        if (toVertex == null)
        {
            toVertex = new Vertex<T>(toValue);
        }

        _graph.AddEdge(fromVertex, toVertex);

        return this;
    }

    public Graph<T> Build() => _graph;
}