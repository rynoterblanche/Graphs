namespace Graphs.Core.Entities;

public class GraphBuilder<T>
{
    private readonly Graph<T> _graph = new();

    public GraphBuilder<T> WithDirectedEdge(T fromValue, T toValue)
    {
        var fromVertex = _graph.FirstOrDefault(v => v.Value.Equals(fromValue));
        if (fromVertex == null)
        {
            fromVertex = new Vertex<T>(fromValue);
            _graph.AddVertex(fromVertex);
        }

        var toVertex = _graph.FirstOrDefault(v => v.Value.Equals(toValue));
        if (toVertex == null)
        {
            toVertex = new Vertex<T>(toValue);
            _graph.AddVertex(toVertex);
        }

        _graph.AddEdge(fromVertex, toVertex);

        return this;
    }

    public Graph<T> Build() => _graph;

}