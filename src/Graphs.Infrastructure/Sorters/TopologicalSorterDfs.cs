using Graphs.Core.Entities;
using Graphs.Core.Interfaces;
using Graphs.Shared.Exceptions;

namespace Graphs.Infrastructure.Sorters;

public class TopologicalSorterDfs<T> : IGraphSorter<T>
{
    public List<Vertex<T>> Sort(IGraph<T> graph)
    {
        var sorted = new List<Vertex<T>>();
        var visited = new Dictionary<Vertex<T>, bool>();

        foreach (var vertex in graph)
        {
            Visit(vertex, sorted, visited);
        }

        return sorted;
    }

    private void Visit(Vertex<T> vertex, ICollection<Vertex<T>> sorted, IDictionary<Vertex<T>, bool> visited)
    {
        var alreadyVisited = visited.TryGetValue(vertex, out var inProcess);

        if (alreadyVisited)
        {
            if (inProcess)
            {
                throw new CyclicGraphException("Cannot sort graph - cyclic dependency found");
            }
        }
        else
        {
            visited[vertex] = true;

            foreach (var neighbor in vertex.Parents)
            {
                Visit(neighbor, sorted, visited);
            }

            visited[vertex] = false;
            sorted.Add(vertex);
        }
    }
}