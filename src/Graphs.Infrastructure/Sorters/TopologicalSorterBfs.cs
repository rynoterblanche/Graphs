using Graphs.Core.Entities;
using Graphs.Core.Interfaces;
using Graphs.Shared.Exceptions;

namespace Graphs.Infrastructure.Sorters;

public class TopologicalSorterBfs<T> : IGraphSorter<T>
{
    public List<Vertex<T>> Sort(IGraph<T> graph)
    {
        List<Vertex<T>> sorted = new();
        var inDegree = new Dictionary<Vertex<T>, int> ();

        foreach (var vertex in graph)
        {
            Visit(vertex, inDegree);
        }

        var verticesWithZeroInDegree = new List<Vertex<T>>();
        foreach (var entry in inDegree)
        {
            if (entry.Value == 0)
            {
                verticesWithZeroInDegree.Add(entry.Key);
            }
        }

        var visitedCount = 0;
        while (verticesWithZeroInDegree.Count > 0)
        {
            var nextVertex = verticesWithZeroInDegree.First();
            verticesWithZeroInDegree.Remove(nextVertex);
            sorted.Add(nextVertex);

            nextVertex.Children.ForEach(neighbor =>
            {
                var hasInDegree = inDegree.TryGetValue(neighbor, out var neighborInDegree);
                if (!hasInDegree || neighborInDegree <= 0)
                {
                    return;
                }

                neighborInDegree--;
                inDegree[neighbor] = neighborInDegree;
                if (neighborInDegree == 0)
                {
                    verticesWithZeroInDegree.Add(neighbor);
                }
            });

            visitedCount++;
        }

        if (visitedCount != inDegree.Count)
            throw new CyclicGraphException("Cannot sort graph - cyclic dependency found");

        return sorted;
    }

    private void Visit(Vertex<T> vertex, IDictionary<Vertex<T>, int> inDegree)
    {
        if (!inDegree.ContainsKey(vertex))
        {
            inDegree[vertex] = 0;
        }

        vertex.Children.ForEach(neighbor =>
        {
            if (inDegree.ContainsKey(neighbor))
            {
                inDegree[neighbor] += 1;
            }
            else
            {
                inDegree[neighbor] = 1;
            }
        });
    }
}