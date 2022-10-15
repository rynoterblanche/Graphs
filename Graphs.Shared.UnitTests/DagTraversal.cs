using Graphs.Core;
using Graphs.Shared.Interfaces;
using Graphs.Shared.Tools;

namespace Graphs.Shared.UnitTests;

public class DagTraversal
{
    [Fact]
    public void TraverseSimpleGraph()
    {
        var graph = new GraphBuilder<string>()
            .WithEdge("A", "B")
            .WithEdge("A", "D")
            .WithEdge("B", "C")
            .WithEdge("C", "D")
            .Build();

        var visitor = new FakeVisitor<string>();
        Dag.Traverse(graph, visitor);

        Assert.Equal(new string[] {"A", "B", "C", "D"}, visitor.VisitedValues);
    }

    [Fact]
    public void TraverseMoreComplexGraph()
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