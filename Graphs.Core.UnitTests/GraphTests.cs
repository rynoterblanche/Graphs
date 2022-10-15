using Graphs.Core.Entities;

namespace Graphs.Core.UnitTests
{
    public class GraphTests
    {
        [Fact]
        public void AddASingleVertex()
        {
            var graph = new Graph<int>();
            graph.AddVertex(new Vertex<int>(1));

            Assert.Single(graph);
            Assert.Equal(1, graph.First().Value);
        }           
        
        [Fact]
        public void AddSeveralVertexes()
        {
            var graph = new Graph<int>();
            graph.AddVertex(new Vertex<int>(1));
            graph.AddVertex(new Vertex<int>(2));
            graph.AddVertex(new Vertex<int>(3));

            Assert.Collection(graph,
                item => Assert.Equal(1, item.Value),
                item => Assert.Equal(2, item.Value),
                item => Assert.Equal(3, item.Value)
            );
        }

        [Fact]
        public void AddingSameVertexMoreThanOnceIsIdempotent()
        {
            var graph = new Graph<int>();
            var vertex = new Vertex<int>(1);
            graph.AddVertex(vertex);
            graph.AddVertex(vertex);

            Assert.Single(graph);
            Assert.Equal(1, graph.First().Value);
        }
    }
}