using Graphs.Core.Entities;
using Graphs.Shared.Tools;

namespace Graphs.Shared.UnitTests
{
    public class DagIsAcyclic
    {
        [Fact]
        public void CyclicGraphReturnsFalse()
        {
            var graph = new Graph<int>();
            var vertexA = new Vertex<int>(1);
            var vertexB = new Vertex<int>(2);
            var vertexC = new Vertex<int>(3);
            graph.AddVertex(vertexA);
            graph.AddVertex(vertexB);
            graph.AddVertex(vertexC);
            graph.AddEdge(vertexA, vertexB);
            graph.AddEdge(vertexB, vertexC);
            graph.AddEdge(vertexC, vertexA);

            Assert.False(Dag.IsAcyclic(graph));
        }

        [Fact]
        public void AcyclicGraphReturnsTrue()
        {
            var graph = new Graph<string>();
            var vertexA = new Vertex<string>("A");
            var vertexB = new Vertex<string>("B");
            var vertexC = new Vertex<string>("C");
            var vertexD = new Vertex<string>("D");
            graph.AddVertex(vertexA);
            graph.AddVertex(vertexB);
            graph.AddVertex(vertexC);
            graph.AddVertex(vertexD);
            graph.AddEdge(vertexA, vertexB);
            graph.AddEdge(vertexA, vertexD);
            graph.AddEdge(vertexB, vertexC);
            graph.AddEdge(vertexC, vertexD);

            Assert.True(Dag.IsAcyclic(graph));
        }
    }
}