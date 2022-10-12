namespace Graphs.Core.UnitTests
{
    public class GraphTests
    {
        [Fact]
        public void AddASingleNode()
        {
            var graph = new Graph<int>();
            graph.AddNode(new GraphNode<int>(1));

            Assert.Single(graph);
            Assert.Equal(1, graph.First().Value);
        }           
        
        [Fact]
        public void AddSeveralNodes()
        {
            var graph = new Graph<int>();
            graph.AddNode(new GraphNode<int>(1));
            graph.AddNode(new GraphNode<int>(2));
            graph.AddNode(new GraphNode<int>(3));

            Assert.Collection(graph,
                item => Assert.Equal(1, item.Value),
                item => Assert.Equal(2, item.Value),
                item => Assert.Equal(3, item.Value)
            );
        }

        [Fact]
        public void AddingSameNodeMoreThanOnceIsIdempotent()
        {
            var graph = new Graph<int>();
            var nodeA = new GraphNode<int>(1);
            graph.AddNode(nodeA);
            graph.AddNode(nodeA);

            Assert.Single(graph);
            Assert.Equal(1, graph.First().Value);
        }
    }
}