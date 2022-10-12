namespace Graphs.Core;

public class GraphEdge<T>
{
    public GraphNode<T> FromNode { get; }
    public GraphNode<T> ToNode { get; }

    public GraphEdge(GraphNode<T> fromNode, GraphNode<T> toNode)
    {
        FromNode = fromNode;
        ToNode = toNode;
    }
}