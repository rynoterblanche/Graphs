using Graphs.Core.Entities;
using Graphs.Infrastructure.Sorters;
using Graphs.Shared.Exceptions;

namespace Graphs.Infrastructure.UnitTests;

public class TopologicalSortBfs
{

    [Fact]
    public void AcyclicGraphSortsCorrectly()
    {
        var graph = new GraphBuilder<string>()
            .WithDirectedEdge("A", "B")
            .WithDirectedEdge("A", "C")
            .WithDirectedEdge("A", "D")
            .WithDirectedEdge("B", "D")
            .WithDirectedEdge("B", "C")
            .WithDirectedEdge("C", "D")
            .WithDirectedEdge("D", "E")
            .WithDirectedEdge("D", "F")
            .WithDirectedEdge("D", "G")
            .WithDirectedEdge("E", "F")
            .WithDirectedEdge("E", "G")
            .WithDirectedEdge("F", "G")
            .WithDirectedEdge("A", "H")
            .WithDirectedEdge("B", "H")
            .WithDirectedEdge("G", "H")
            .WithDirectedEdge("H", "I")
            .WithDirectedEdge("D", "I")
            .WithDirectedEdge("I", "J")
            .WithDirectedEdge("I", "K")
            .WithDirectedEdge("J", "K")
            .Build();

        var sorted = new TopologicalSorterBfs<string>().Sort(graph);
        var sortedValues = string.Join("", sorted.Select(node => node.Value));
        Assert.Equal("ABCDEFGHIJK", sortedValues);
    }

    [Fact]
    public void CyclicGraphRaisesError()
    {
        var graph = new GraphBuilder<string>()
            .WithDirectedEdge("A", "B")
            .WithDirectedEdge("A", "D")
            .WithDirectedEdge("B", "C")
            .WithDirectedEdge("C", "A")
            .Build();

        var topologicalSorterBfs = new TopologicalSorterBfs<string>();

        void Action() => topologicalSorterBfs.Sort(graph);

        Assert.Throws<CyclicGraphException<string>>(Action);
    }

}