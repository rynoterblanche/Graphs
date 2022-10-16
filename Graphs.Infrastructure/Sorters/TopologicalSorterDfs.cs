using Graphs.Core.Entities;
using Graphs.Core.Interfaces;

namespace Graphs.Infrastructure.Sorters;

public class TopologicalSorterDfs<T> : IGraphSorter<T>
{
    public List<Vertex<T>> Sort(Graph<T> graph)
    {
        var sorted = new List<Vertex<T>>();
        var visited = new Dictionary<Vertex<T>, bool>();

        foreach (var vertex in graph)
        {
            Visit(vertex, sorted, visited);
        }

        return sorted;
    }

    private void Visit(Vertex<T> vertex, List<Vertex<T>> sorted, Dictionary<Vertex<T>, bool> visited)
    {
        bool inProcess;
        var alreadyVisited = visited.TryGetValue(vertex, out inProcess);

        if (alreadyVisited)
        {
            if (inProcess)
            {
                throw new ArgumentException("Cyclic dependency found.");
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