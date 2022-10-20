using Graphs.Core.Entities;
using Graphs.Infrastructure.Sorters;
using Graphs.Shared.Exceptions;

namespace Graphs.Infrastructure.UnitTests;

public class TopologicalSortBfs
{

    [Theory]
    [AcyclicSortingData]
    public void AcyclicGraphSortsCorrectly(Graph<string> graph, string expectedSortResult)
    {
        var sorted = new TopologicalSorterBfs<string>().Sort(graph);
        var sortedValues = string.Join("", sorted.Select(node => node.Value));
        
        Assert.Equal(expectedSortResult, sortedValues);
    }

    [Theory]
    [CyclicSortingData]
    public void CyclicGraphRaisesError(Graph<string> graph)
    {
        var topologicalSorterBfs = new TopologicalSorterBfs<string>();

        void Action() => topologicalSorterBfs.Sort(graph);

        Assert.Throws<CyclicGraphException<string>>(Action);
    }

}