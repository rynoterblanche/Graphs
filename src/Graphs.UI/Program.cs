using System.Text;
using Graphs.Core.Entities;
using Graphs.Infrastructure.Logging;
using Graphs.Infrastructure.Printers;using Graphs.Shared.Tools;

var graph = Dag.GenerateRandomGraph(5, 25, 5, 25, 75);

new AdjacencyListPrinter<int>(new ConsoleLogger()).Print(graph);

var adjList = GetAdjListAsString(graph);

File.WriteAllText("C:\\work\\Graphs\\src\\Graphs.UI\\dagAdjList.txt", adjList);

string GetAdjListAsString(Graph<int> vertices)
{
    var stringBuilder = new StringBuilder();
    foreach (var vertex in vertices)
    {
        var neighbors = vertex.Children.Aggregate(string.Empty, (s, v) => $"{s}{v.Value},").TrimEnd(',');
        stringBuilder.Append($"{vertex.Value} -> {neighbors}\n");
    }

    var adjList1 = stringBuilder.ToString();
    return adjList1;
}