using Graphs.Infrastructure.Logging;
using Graphs.Infrastructure.Printers;
using Graphs.Shared.Builders;

var graph = new GraphBuilder<int>()
    .WithEdge(1, 2)
    .WithEdge(1, 3)
    .WithEdge(2, 4)
    .WithEdge(3, 4)
    .WithEdge(1, 4)
    .Build();

new AdjacencyListPrinter<int>(new ConsoleLogger()).Print(graph);