﻿using Graphs.Core;
using Graphs.Core.Entities;
using Graphs.Shared.Tools;

namespace Graphs.Shared.UnitTests;

public class DagNaiveTopoSort
{
    [Fact]
    public void SimpleGraphOrder()
    {
        var graph = new GraphBuilder<string>()
            .WithDirectedEdge("A", "B")
            .WithDirectedEdge("A", "D")
            .WithDirectedEdge("B", "C")
            .WithDirectedEdge("C", "D")
            .Build();

        var sorted = Dag.TopoSort(graph);

        var sortedValues = string.Join("", sorted.Select(node => node.Value));
        Assert.Equal("ABCD", sortedValues);
    }

    [Fact]
    public void MoreComplexGraphOrder()
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

        var sorted = Dag.TopoSort(graph);
        var sortedValues = string.Join("", sorted.Select(node => node.Value));
        Assert.Equal("ABCDEFGHIJK", sortedValues);
    }

}