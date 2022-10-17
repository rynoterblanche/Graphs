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

    public static Graph<int> GenerateRandomGraph(int minWidth = 1,
        int maxWidth = 5,
        int minDepth = 3,
        int maxDepth = 5,
        int percentageChanceForEdge = 30)
    {
        var graph = new Graph<int>();

        var random = new Random();

        var depth = minDepth + (random.Next() % (maxDepth - minDepth + 1));

        int i, j, k, vertices = 0;
        for (i = 0; i < depth; i++)
        {
            var width = minWidth + random.Next() % (maxWidth - minWidth + 1);

            for (j = 1; j < vertices + 1; j++)
            {
                var fromVertex = graph.FirstOrDefault(vertex => vertex.Value == j);
                if (fromVertex == null)
                {
                    fromVertex = new Vertex<int>(j);
                    graph.AddVertex(fromVertex);
                }

                for (k = 1; k < width + 1; k++)
                {
                    if ((random.Next() % 100) < percentageChanceForEdge)
                    {
                        var nextValue = k + vertices;

                        var toVertex = graph.FirstOrDefault(vertex => vertex.Value == nextValue);
                        if (toVertex == null)
                        {
                            toVertex = new Vertex<int>(nextValue);
                            graph.AddVertex(toVertex);
                        }

                        graph.AddDirectedEdge(fromVertex, toVertex);
                    }
                }
            }

            vertices += width;
        }

        return graph;
    }

}