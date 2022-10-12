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
            var nodeA = new GraphNode<int>(1);
            var nodeB = new GraphNode<int>(2);
            var nodeC = new GraphNode<int>(3);
            graph.AddNode(nodeA);
            graph.AddNode(nodeB);
            graph.AddNode(nodeC);
            graph.AddDirectedEdge(nodeA, nodeB);
            graph.AddDirectedEdge(nodeB, nodeC);
            graph.AddDirectedEdge(nodeC, nodeA);

            Assert.False(Dag.IsAcyclic(graph));
        }

        [Fact]
        public void AcyclicGraphReturnsTrue()
        {
            var graph = new Graph<string>();
            var nodeA = new GraphNode<string>("A");
            var nodeB = new GraphNode<string>("B");
            var nodeC = new GraphNode<string>("C");
            var nodeD = new GraphNode<string>("D");
            graph.AddNode(nodeA);
            graph.AddNode(nodeB);
            graph.AddNode(nodeC);
            graph.AddNode(nodeD);
            graph.AddDirectedEdge(nodeA, nodeB);
            graph.AddDirectedEdge(nodeA, nodeD);
            graph.AddDirectedEdge(nodeB, nodeC);
            graph.AddDirectedEdge(nodeC, nodeD);

            Assert.True(Dag.IsAcyclic(graph));
        }
    }
}