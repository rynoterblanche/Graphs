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
        var graph = new AdjacencyListLoader().Load(adjListString);

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
        var graph = new AdjacencyListLoader().Load(adjListString);

        Assert.Equal(7, graph.Edges.Count);
    }
}