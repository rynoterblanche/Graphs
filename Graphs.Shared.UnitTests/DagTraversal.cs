using Graphs.Core;
using Graphs.Core.Entities;
using Graphs.Core.Interfaces;
using Graphs.Shared.Tools;

namespace Graphs.Shared.UnitTests;

public class DagTraversal
{
    [Fact]
    public void TraverseSimpleGraph()
    {
        var graph = new GraphBuilder<string>()
            .WithDirectedEdge("A", "B")
            .WithDirectedEdge("A", "D")
            .WithDirectedEdge("B", "C")
            .WithDirectedEdge("C", "D")
            .Build();

        var visitor = new FakeVisitor<string>();
        Dag.Traverse(graph, visitor);

        Assert.Equal(new string[] {"A", "B", "C", "D"}, visitor.VisitedValues);
    }

    [Fact]
    public void TraverseMoreComplexGraph()
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

        var visitor = new FakeVisitor<string>();
        Dag.Traverse(graph, visitor);

        Assert.Equal(new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"}, visitor.VisitedValues);
    }
}

public class FakeVisitor<T> : IGraphVisitor<T>
{
    public List<string> VisitedValues = new();

    public void Visit(Vertex<T> nextVertex)
    {
        VisitedValues.Add(nextVertex.Value.ToString());
    }
}