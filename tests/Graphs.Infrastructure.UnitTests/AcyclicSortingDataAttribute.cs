using Graphs.Core.Entities;
using System.Reflection;
using Graphs.Shared.Builders;
using Xunit.Sdk;

namespace Graphs.Infrastructure.UnitTests;

public class AcyclicSortingDataAttribute: DataAttribute
{
    private static readonly Graph<string> _graphA = new GraphBuilder<string>()
        .WithEdge("A", "B")
        .WithEdge("A", "D")
        .WithEdge("B", "D")
        .WithEdge("B", "C")
        .WithEdge("C", "D")
        .WithEdge("D", "E")
        .WithEdge("I", "K")
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
        .WithEdge("A", "C")
        .WithEdge("I", "J")
        .WithEdge("J", "K")
        .Build();

    private static readonly string _graphASortedResult = "ABCDEFGHIJK";

    private static readonly Graph<string> _graphB = new GraphBuilder<string>()
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
        .WithEdge("A", "K")
        .WithEdge("B", "K")
        .WithEdge("K", "L")
        .WithEdge("L", "M")
        .WithEdge("A", "B")
        .WithEdge("A", "C")
        .WithEdge("A", "D")
        .WithEdge("B", "D")
        .WithEdge("B", "C")
        .WithEdge("C", "D")
        .WithEdge("D", "E")
        .WithEdge("D", "F")
        .WithEdge("D", "G")
        .WithEdge("K", "M")
        .Build();

    private static readonly string _graphBSortedResult = "ABCDEFGHIJKLM";

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { _graphA, _graphASortedResult };
        yield return new object[] { _graphB, _graphBSortedResult };
    }
}