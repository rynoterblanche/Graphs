using Graphs.Core.Entities;
using Graphs.Infrastructure.Logging;
using Graphs.Infrastructure.Printers;
using Graphs.Infrastructure.Sorters;
using Graphs.Shared.Interfaces;
using Graphs.Shared.Tools;

var graph = Dag.GenerateRandomGraph();

Console.WriteLine("=====================");

var adjacencyListPrinter = new AdjacencyListPrinter<int>(new ConsoleLogger());

adjacencyListPrinter.Print(graph);

Console.WriteLine("=====================");

var topologicalSorterBfs = new TopologicalSorterBfs<int>();

var sorted = graph.Sort(topologicalSorterBfs);
foreach (var vertex in sorted)
{
    var childValues = vertex.Children.Select(v => v.Value);
    Console.WriteLine($"{vertex.Value} -> {string.Join(",", childValues)}");
}

