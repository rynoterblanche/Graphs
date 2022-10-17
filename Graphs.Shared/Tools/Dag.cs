using Graphs.Core.Entities;
using Graphs.Core.Interfaces;
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

    public static List<Vertex<T>> TopoSort<T>(Graph<T> graph)
    {
        var sorted = new List<Vertex<T>>();
        
        var nodesWithDependencies = graph.Edges.Select(edge => edge.ToVertex);
        var nodesWithNoDependencies = graph.Where(node => !nodesWithDependencies.Contains(node)).ToList();

        var tempEdges = graph.Edges.ToList();

        while (nodesWithNoDependencies.Count > 0)
        {
            var nextNode = nodesWithNoDependencies.First();
            nodesWithNoDependencies.Remove(nextNode);
            sorted.Add(nextNode);

            var edges = graph.Edges
                .Where(edge => edge.FromVertex == nextNode)
                .ToList();
            foreach (var edge in edges)
            {
                tempEdges.Remove(edge);

                if (tempEdges.Any(e => e.ToVertex == edge.ToVertex))
                    continue;

                nodesWithNoDependencies.Add(edge.ToVertex);
            }
        }

        if (tempEdges.Count > 0)
            throw new CyclicGraphException<T>("Cannot sort graph - cyclic dependencies found");

        return sorted;
    }

    public static void Traverse<T>(Graph<T> graph, IGraphVisitor<T> visitor)
    {
        var nodesWithDependencies = graph.Edges.Select(edge => edge.ToVertex);
        var nodesWithNoDependencies = graph.Where(node => !nodesWithDependencies.Contains(node)).ToList();

        var tempEdges = graph.Edges.ToList();

        while (nodesWithNoDependencies.Count > 0)
        {
            var nextNode = nodesWithNoDependencies.First();
            nodesWithNoDependencies.Remove(nextNode);
            visitor.Visit(nextNode);

            var edges = graph.Edges
                .Where(edge => edge.FromVertex == nextNode)
                .ToList();
            foreach (var edge in edges)
            {
                tempEdges.Remove(edge);

                if (tempEdges.Any(e => e.ToVertex == edge.ToVertex))
                    continue;

                nodesWithNoDependencies.Add(edge.ToVertex);
            }
        }
    }

}