using Graphs.Core.Entities;

namespace Graphs.Core.UnitTests;

public class DirectedGraphTests
{
    [Fact]
    public void AddAnEdge()
    {
        var graph = new Graph<int>();
        var vertexA = new Vertex<int>(1);
        var vertexB = new Vertex<int>(2);
        graph.AddVertex(vertexA);
        graph.AddVertex(vertexB);
        graph.AddDirectedEdge(vertexA, vertexB);

        var edge = graph.Edges.First();
        Assert.Equal(vertexA, edge.FromVertex);
        Assert.Equal(vertexB, edge.ToVertex);
    }

    [Fact]
    public void AddingAnEdgeSetsParentAndChild()
    {
        var graph = new Graph<int>();
        var vertexA = new Vertex<int>(1);
        var vertexB = new Vertex<int>(2);
        graph.AddVertex(vertexA);
        graph.AddVertex(vertexB);
        graph.AddDirectedEdge(vertexA, vertexB);

        Assert.Equal(vertexB, vertexA.Children[0]);
        Assert.Equal(vertexA, vertexB.Parents[0]);
    }

    [Fact]
    public void AddSeveralEdges()
    {
        var graph = new Graph<int>();
        var vertexA = new Vertex<int>(1);
        var vertexB = new Vertex<int>(2);
        var vertexC = new Vertex<int>(3);
        graph.AddVertex(vertexA);
        graph.AddVertex(vertexB);
        graph.AddVertex(vertexC);
        graph.AddDirectedEdge(vertexA, vertexB);
        graph.AddDirectedEdge(vertexA, vertexC);

        var edge1 = graph.Edges[0];
        Assert.Equal(vertexA, edge1.FromVertex);
        Assert.Equal(vertexB, edge1.ToVertex);

        var edge2 = graph.Edges[1];
        Assert.Equal(vertexA, edge2.FromVertex);
        Assert.Equal(vertexC, edge2.ToVertex);
    }

    [Fact]
    public void AddingSameEdgeMoreThanOnceIsIdempotent()
    {
        var graph = new Graph<int>();
        var vertexA = new Vertex<int>(1);
        var vertexB = new Vertex<int>(2);
        graph.AddVertex(vertexA);
        graph.AddVertex(vertexB);
        graph.AddDirectedEdge(vertexA, vertexB);
        graph.AddDirectedEdge(vertexA, vertexB);

        Assert.Single(graph.Edges);
    }
}