using Graphs.Core.Entities;
using Graphs.Infrastructure.Sorters;
using Graphs.Shared.Exceptions;

namespace Graphs.Infrastructure.UnitTests;

public class TopologicalSortDfs
{

    [Theory]
    [AcyclicSortingData]
    public void AcyclicGraphSortsCorrectly(Graph<string> graph, string expectedSortResult)
    {
        var sorted = new TopologicalSorterDfs<string>().Sort(graph);
        var sortedValues = string.Join("", sorted.Select(node => node.Value));
        
        Assert.Equal(expectedSortResult, sortedValues);
    }

    [Theory]
    [CyclicSortingData]
    public void CyclicGraphRaisesError(Graph<string> graph)
    {
        var topologicalSorterDfs = new TopologicalSorterDfs<string>();
        
        void Action() => topologicalSorterDfs.Sort(graph);
        
        Assert.Throws<CyclicGraphException>(Action);
    }

}