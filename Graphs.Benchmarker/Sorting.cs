using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using Graphs.Core.Entities;
using Graphs.Infrastructure.Sorters;

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
            .WithDirectedEdge(1, 2)
            .WithDirectedEdge(1, 3)
            .WithDirectedEdge(1, 4)
            .WithDirectedEdge(2, 4)
            .WithDirectedEdge(2, 6)
            .WithDirectedEdge(4, 6)
            .WithDirectedEdge(4, 5)
            .WithDirectedEdge(4, 7)
            .WithDirectedEdge(5, 7)
            .WithDirectedEdge(6, 7)
            .WithDirectedEdge(1, 7)
            .WithDirectedEdge(7, 8)
            .Build();
        return graph;
    }
}