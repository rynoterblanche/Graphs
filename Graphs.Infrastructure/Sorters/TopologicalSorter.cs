using Graphs.Core.Entities;
using Graphs.Core.Interfaces;

namespace Graphs.Infrastructure.Sorters;

public class TopologicalSorter<T> : IGraphSorter<T>
{
    public List<Vertex<T>> Sort(Graph<T> graph)
    {
        List<Vertex<T>> sorted = new();
        var inDegree = new Dictionary<Vertex<T>, int> ();

        foreach (var vertex in graph)
        {
            if (!inDegree.ContainsKey(vertex))
            {
                inDegree[vertex] = 0;
            }

            vertex.Neighbors.ForEach(neighbor =>
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

        var verticesWithZeroInDegree = new List<Vertex<T>>();
        foreach (KeyValuePair<Vertex<T>, int> entry in inDegree)
        {
            if (entry.Value == 0)
            {
                verticesWithZeroInDegree.Add(entry.Key);
            }
        }

        while (verticesWithZeroInDegree.Count > 0)
        {
            var nextVertex = verticesWithZeroInDegree.First();
            sorted.Add(nextVertex);
            verticesWithZeroInDegree.Remove(nextVertex);

            if (graph.Contains(nextVertex))
            {
                nextVertex.Neighbors.ForEach(neighbor =>
                {
                    if (inDegree.ContainsKey(neighbor) && inDegree[neighbor] > 0)
                    {
                        var newDegree = inDegree[neighbor] - 1;
                        inDegree[neighbor] = newDegree;

                        if (newDegree == 0)
                        {
                            verticesWithZeroInDegree.Add(neighbor);
                        }
                    }
                });
            }
        }

        return sorted;
    }
}