using System.Collections.ObjectModel;

namespace Graphs.Core;

public class NodeList<T> : Collection<GraphNode<T>>
{
    public NodeList() { }

    public Node<T> FindByValue(T value)
    {
        foreach (Node<T> node in Items)
            if (node.Value.Equals(value))
                return node;

        return null;
    }
}