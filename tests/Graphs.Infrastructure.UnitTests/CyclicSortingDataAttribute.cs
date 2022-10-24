using Graphs.Core.Entities;
using System.Reflection;
using Graphs.Shared.Builders;
using Xunit.Sdk;

namespace Graphs.Infrastructure.UnitTests;

public class CyclicSortingDataAttribute: DataAttribute
{
    private static readonly Graph<string> _graphA = new GraphBuilder<string>()
        .WithEdge("A", "B")
        .WithEdge("A", "D")
        .WithEdge("B", "C")
        .WithEdge("C", "A")
        .Build();

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { _graphA };
    }
}