using Graphs.Core.Entities;

namespace Graphs.Infrastructure.UnitTests;

public class AdjacencyListLoaderLoad
{
    [Fact]
    public void AcyclicGraphHasCorrectNodes()
    {
        var adjListString = "1 -> 2,5\n" +
                            "2 -> 3,4\n" +
                            "1 -> 4\n" +
                            "3 -> 5\n" +
                            "4 -> 5\n" +
                            "5 ->";
        var graph = new AdjacencyListLoader<string>().Load(adjListString);

        Assert.Collection(graph,
            item => Assert.Equal("1", item.Value),
            item => Assert.Equal("2", item.Value),
            item => Assert.Equal("5", item.Value),
            item => Assert.Equal("3", item.Value),
            item => Assert.Equal("4", item.Value)
        );
    }

    [Fact]
    public void AcyclicGraphHasCorrectEdges()
    {
        var adjListString = "1 -> 2,5\n" +
                            "2 -> 3,4\n" +
                            "1 -> 4\n" +
                            "3 -> 5\n" +
                            "4 -> 5\n" +
                            "5 ->";
        var graph = new AdjacencyListLoader<string>().Load(adjListString);

        Assert.Equal(7, graph.Edges.Count);
    }
}

public class AdjacencyListLoader<T>: IGraphLoader<T>
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

                graph.AddDirectedEdge(vertex, neighbor);
            }
        }

        return graph;
    }
}

public interface IGraphLoader<T>
{
    public Graph<string> Load(string graphContent);
}

