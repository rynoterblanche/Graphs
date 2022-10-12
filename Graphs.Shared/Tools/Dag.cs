using Graphs.Core;
using Graphs.Shared.Exceptions;

namespace Graphs.Shared.Tools;

public class Dag
{
    public static bool IsAcyclic<T>(Graph<T> graph)
    {
        try
        {
            Dag.TopoSort(graph);
        }
        catch (CyclicGraphException<T>)
        {
            return false;
        }

        return true;
    }

    public static List<GraphNode<T>> TopoSort<T>(Graph<T> graph)
    {
        var sorted = new List<GraphNode<T>>();
        
        var nodesWithDependencies = graph.Edges.Select(edge => edge.ToNode);
        var nodesWithNoDependencies = graph.Where(node => !nodesWithDependencies.Contains(node)).ToList();

        var tempEdges = graph.Edges.ToList();

        while (nodesWithNoDependencies.Count > 0)
        {
            var nextNode = nodesWithNoDependencies.First();
            nodesWithNoDependencies.Remove(nextNode);
            sorted.Add(nextNode);

            var edges = graph.Edges
                .Where(edge => edge.FromNode == nextNode)
                .ToList();
            foreach (var edge in edges)
            {
                tempEdges.Remove(edge);

                if (tempEdges.Any(e => e.ToNode == edge.ToNode))
                    continue;

                nodesWithNoDependencies.Add(edge.ToNode);
            }
        }

        if (tempEdges.Count > 0)
            throw new CyclicGraphException<T>("Cannot sort cyclic graph!", tempEdges);

        return sorted;
    }
}