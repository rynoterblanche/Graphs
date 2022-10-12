namespace Graphs.Core.UnitTests;

public class DirectedGraphTests
{
    [Fact]
    public void AddAnEdge()
    {
        var graph = new Graph<int>();
        var nodeA = new GraphNode<int>(1);
        var nodeB = new GraphNode<int>(2);
        graph.AddNode(nodeA);
        graph.AddNode(nodeB);
        graph.AddDirectedEdge(nodeA, nodeB);

        Assert.Equal(2, nodeA.Neighbors.First().Value);
    }

    [Fact]
    public void AddSeveralEdges()
    {
        var graph = new Graph<int>();
        var nodeA = new GraphNode<int>(1);
        var nodeB = new GraphNode<int>(2);
        var nodeC = new GraphNode<int>(3);
        graph.AddNode(nodeA);
        graph.AddNode(nodeB);
        graph.AddNode(nodeC);
        graph.AddDirectedEdge(nodeA, nodeB);
        graph.AddDirectedEdge(nodeA, nodeC);

        Assert.Collection(nodeA.Neighbors,
            item => Assert.Equal(2, item.Value),
            item => Assert.Equal(3, item.Value)
        );
    }

    [Fact]
    public void AddingSameEdgeMoreThanOnceIsIdempotent()
    {
        var graph = new Graph<int>();
        var nodeA = new GraphNode<int>(1);
        var nodeB = new GraphNode<int>(2);
        graph.AddNode(nodeA);
        graph.AddNode(nodeB);
        graph.AddDirectedEdge(nodeA, nodeB);
        graph.AddDirectedEdge(nodeA, nodeB);

        Assert.Single(nodeA.Neighbors);
        Assert.Equal(2, nodeA.Neighbors.First().Value);
    }
}