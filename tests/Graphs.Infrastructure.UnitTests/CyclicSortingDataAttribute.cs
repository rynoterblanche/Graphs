using Graphs.Core.Entities;
using System.Reflection;
using Xunit.Sdk;

namespace Graphs.Infrastructure.UnitTests;

public class CyclicSortingDataAttribute: DataAttribute
{
    private static readonly Graph<string> _graphA = new GraphBuilder<string>()
        .WithDirectedEdge("A", "B")
        .WithDirectedEdge("A", "D")
        .WithDirectedEdge("B", "C")
        .WithDirectedEdge("C", "A")
        .Build();

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { _graphA };
    }
}