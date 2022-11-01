using Graphs.Core.Entities;

namespace Graphs.Infrastructure.UnitTests;

public class AdjacencyListLoader: IGraphLoader<string>
{
    private const string Separator = "->";

    public Graph<string> Load(string graphContent)
    {
        var graph = new Graph<string>();

        using var reader = new StringReader(graphContent);

        var verticesAdded = new Dictionary<string, Vertex<string>>();

        for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
        {
            var trimmed = string.Concat(line.Where(c => !char.IsWhiteSpace(c)));
            
            var strings = trimmed.Split(Separator);
            var vertexValue = strings[0];

            if (string.IsNullOrEmpty(vertexValue))
                continue;

            if (!verticesAdded.TryGetValue(vertexValue, out var vertex))
            {
                vertex = new Vertex<string>(vertexValue);
                graph.AddVertex(vertex);
                verticesAdded[vertex.Value] = vertex;
            }

            var neighborsValues = strings[1]
                .Split(',');

            foreach (var neighborValue in neighborsValues)
            {
                if (string.IsNullOrEmpty(neighborValue))
                    continue;

                if (!verticesAdded.TryGetValue(neighborValue, out var neighbor))
                {
                    neighbor = new Vertex<string>(neighborValue);
                    graph.AddVertex(neighbor);
                    verticesAdded[neighbor.Value] = neighbor;
                }

                graph.AddEdge(vertex, neighbor);
            }
        }

        return graph;
    }
}