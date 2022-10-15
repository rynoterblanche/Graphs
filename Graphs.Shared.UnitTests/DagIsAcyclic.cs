using Graphs.Core;
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
            graph.AddDirectedEdge(vertexA, vertexB);
            graph.AddDirectedEdge(vertexB, vertexC);
            graph.AddDirectedEdge(vertexC, vertexA);

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
            graph.AddDirectedEdge(vertexA, vertexB);
            graph.AddDirectedEdge(vertexA, vertexD);
            graph.AddDirectedEdge(vertexB, vertexC);
            graph.AddDirectedEdge(vertexC, vertexD);

            Assert.True(Dag.IsAcyclic(graph));
        }
    }
}