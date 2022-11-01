using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using Graphs.Core.Entities;
using Graphs.Infrastructure.Sorters;
using Graphs.Shared.Builders;

namespace Graphs.Benchmarker;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn(NumeralSystem.Arabic)]
public class Sorting
{

    [Benchmark]
    public void TopologicalSortBfs()
    {
        new TopologicalSorterBfs<int>().Sort(GetSampleGraph());
    }

    [Benchmark]
    public void TopologicalSortDfs()
    {
        new TopologicalSorterDfs<int>().Sort(GetSampleGraph());
    }

    private Graph<int> GetSampleGraph()
    {
        var graph = new GraphBuilder<int>()
            .WithEdge(1, 2)
            .WithEdge(1, 3)
            .WithEdge(1, 4)
            .WithEdge(2, 4)
            .WithEdge(2, 6)
            .WithEdge(4, 6)
            .WithEdge(4, 5)
            .WithEdge(4, 7)
            .WithEdge(5, 7)
            .WithEdge(6, 7)
            .WithEdge(1, 7)
            .WithEdge(7, 8)
            .Build();
        return graph;
    }
}