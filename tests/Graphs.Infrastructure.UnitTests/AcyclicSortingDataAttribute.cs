using Graphs.Core.Entities;
using System.Reflection;
using Xunit.Sdk;

namespace Graphs.Infrastructure.UnitTests;

public class AcyclicSortingDataAttribute: DataAttribute
{
    private static readonly Graph<string> _graphA = new GraphBuilder<string>()
        .WithDirectedEdge("A", "B")
        .WithDirectedEdge("A", "D")
        .WithDirectedEdge("B", "D")
        .WithDirectedEdge("B", "C")
        .WithDirectedEdge("C", "D")
        .WithDirectedEdge("D", "E")
        .WithDirectedEdge("I", "K")
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
        .WithDirectedEdge("A", "C")
        .WithDirectedEdge("I", "J")
        .WithDirectedEdge("J", "K")
        .Build();

    private static readonly string _graphASortedResult = "ABCDEFGHIJK";

    private static readonly Graph<string> _graphB = new GraphBuilder<string>()
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
        .WithDirectedEdge("A", "K")
        .WithDirectedEdge("B", "K")
        .WithDirectedEdge("K", "L")
        .WithDirectedEdge("L", "M")
        .WithDirectedEdge("A", "B")
        .WithDirectedEdge("A", "C")
        .WithDirectedEdge("A", "D")
        .WithDirectedEdge("B", "D")
        .WithDirectedEdge("B", "C")
        .WithDirectedEdge("C", "D")
        .WithDirectedEdge("D", "E")
        .WithDirectedEdge("D", "F")
        .WithDirectedEdge("D", "G")
        .WithDirectedEdge("K", "M")
        .Build();

    private static readonly string _graphBSortedResult = "ABCDEFGHIJKLM";

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { _graphA, _graphASortedResult };
        yield return new object[] { _graphB, _graphBSortedResult };
    }
}