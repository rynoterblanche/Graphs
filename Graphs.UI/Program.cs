using Graphs.Core.Entities;
using Graphs.Infrastructure.Logging;
using Graphs.Infrastructure.Printers;

var graph = new GraphBuilder<int>()
    .WithDirectedEdge(1, 2)
    .WithDirectedEdge(1, 3)
    .WithDirectedEdge(2, 4)
    .WithDirectedEdge(3, 4)
    .WithDirectedEdge(1, 4)
    .Build();

new AdjacencyListPrinter<int>(new ConsoleLogger()).Print(graph);