using Graphs.Core;
using Graphs.Shared.Tools;

namespace Graphs.Shared.UnitTests;

public class DagTopoSort
{
    [Fact]
    public void SimpleGraphOrder()
    {
        var graph = new Graph<string>();
        AddEdgeToGraph("A", "B", graph);
        AddEdgeToGraph("A", "D", graph);
        AddEdgeToGraph("B", "C", graph);
        AddEdgeToGraph("C", "D", graph);

        var sorted = Dag.TopoSort(graph);

        var sortedValues = string.Join("", sorted.Select(node =>  node.Value));
        Assert.Equal("ABCD", sortedValues);
    }
    
    [Fact]
    public void MoreComplexGraphOrder()
    {
        var graph = new Graph<string>();
        AddEdgeToGraph("A", "B", graph);
        AddEdgeToGraph("A", "C", graph);
        AddEdgeToGraph("A", "D", graph);
        AddEdgeToGraph("B", "D", graph);
        AddEdgeToGraph("B", "C", graph);
        AddEdgeToGraph("C", "D", graph);
        AddEdgeToGraph("D", "E", graph);
        AddEdgeToGraph("D", "F", graph);
        AddEdgeToGraph("D", "G", graph);
        AddEdgeToGraph("E", "F", graph);
        AddEdgeToGraph("E", "G", graph);
        AddEdgeToGraph("F", "G", graph);
        AddEdgeToGraph("A", "H", graph);
        AddEdgeToGraph("B", "H", graph);
        AddEdgeToGraph("G", "H", graph);
        AddEdgeToGraph("H", "I", graph);
        AddEdgeToGraph("D", "I", graph);
        AddEdgeToGraph("I", "J", graph);
        AddEdgeToGraph("I", "K", graph);
        AddEdgeToGraph("J", "K", graph);

        var sorted = Dag.TopoSort(graph);
        var sortedValues = string.Join("", sorted.Select(node =>  node.Value));
        Assert.Equal("ABCDEFGHIJK", sortedValues);
    }

    private void AddEdgeToGraph(string fromValue, string toValue, Graph<string> graph)
    {
        var fromNode = graph.FirstOrDefault(node => node.Value.Equals(fromValue));
        if (fromNode == null)
        {
            fromNode = new GraphNode<string>(fromValue);
            graph.AddNode(fromNode);
        }

        var toNode = graph.FirstOrDefault(node => node.Value.Equals(toValue));
        if (toNode == null)
        {
            toNode = new GraphNode<string>(toValue);
            graph.AddNode(toNode);
        }

        graph.AddDirectedEdge(fromNode, toNode);
    }
}