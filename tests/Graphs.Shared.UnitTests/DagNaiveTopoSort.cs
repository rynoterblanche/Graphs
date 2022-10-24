using Graphs.Shared.Builders;
using Graphs.Shared.Tools;

namespace Graphs.Shared.UnitTests;

public class DagNaiveTopoSort
{
    [Fact]
    public void SimpleGraphOrder()
    {
        var graph = new GraphBuilder<string>()
            .WithEdge("A", "B")
            .WithEdge("A", "D")
            .WithEdge("B", "C")
            .WithEdge("C", "D")
            .Build();

        var sorted = Dag.TopoSort(graph);

        var sortedValues = string.Join("", sorted.Select(node => node.Value));
        Assert.Equal("ABCD", sortedValues);
    }

    [Fact]
    public void MoreComplexGraphOrder()
    {
        var graph = new GraphBuilder<string>()
            .WithEdge("A", "B")
            .WithEdge("A", "C")
            .WithEdge("A", "D")
            .WithEdge("B", "D")
            .WithEdge("B", "C")
            .WithEdge("C", "D")
            .WithEdge("D", "E")
            .WithEdge("D", "F")
            .WithEdge("D", "G")
            .WithEdge("E", "F")
            .WithEdge("E", "G")
            .WithEdge("F", "G")
            .WithEdge("A", "H")
            .WithEdge("B", "H")
            .WithEdge("G", "H")
            .WithEdge("H", "I")
            .WithEdge("D", "I")
            .WithEdge("I", "J")
            .WithEdge("I", "K")
            .WithEdge("J", "K")
            .Build();

        var sorted = Dag.TopoSort(graph);
        var sortedValues = string.Join("", sorted.Select(node => node.Value));
        Assert.Equal("ABCDEFGHIJK", sortedValues);
    }

}