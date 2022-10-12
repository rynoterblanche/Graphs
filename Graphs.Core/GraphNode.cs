namespace Graphs.Core;

public class GraphNode<T> : Node<T>
{
    public GraphNode(T value) : base(value) { }
    public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }
    public new NodeList<T> Neighbors => base.Neighbors ?? (base.Neighbors = new NodeList<T>());
}