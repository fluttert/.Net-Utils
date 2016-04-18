using Fluttert.Utils.Graphs;
using System.Collections.Generic;
using System.Text;

namespace Fluttert.Utils.Tree
{
    /// <summary>
    /// Directed graph
    /// </summary>
    public class DirectedGraph : IGraph
    {
        public DirectedGraph(int vertices)
        {
            this.vertices = vertices;
            edges = 0;
            adjacencyList = new List<int>[vertices];
            for (int v = 0; v < vertices; v++)
            {
                adjacencyList[v] = new List<int>();
            }
        }

        private readonly int vertices;
        private readonly List<int>[] adjacencyList;
        private readonly List<int[]> addedEdges;
        private int edges;

        /// <summary>
        /// Total amount of vertices in this graph
        /// </summary>
        /// <returns>integer, amount of vertices</returns>
        public int Vertices() => vertices;

        /// <summary>
        /// Total amount of edges in this graph
        /// </summary>
        /// <returns>integer, amount of edges</returns>
        public int Edges() => edges;

        public void AddEdge(int v, int w)
        {
            adjacencyList[v].Add(w);
            edges++;
        }

        /// <summary>
        /// Returns all vertices (id's) that are adjecent to this vertex
        /// </summary>
        /// <param name="vertex">id of vertex</param>
        /// <returns>List with ID's of connected vertices</returns>
        public IEnumerable<int> AdjecentVertices(int v) => adjacencyList[v];

        /// <summary>
        /// Standard representation of the directed graph
        /// </summary>
        /// <returns>string</returns>
        public override string ToString() => GraphUtil.Stringify(this);

        /// <summary>
        /// Reverse the directed edges in the graph
        /// </summary>
        /// <returns></returns>
        public DirectedGraph Reverse()
        {
            var reversedGraph = new DirectedGraph(vertices);
            for (int v = 0; v < vertices; v++)
            {
                foreach (var w in AdjecentVertices(v))
                {
                    reversedGraph.AddEdge(w, v);
                }
            }
            return reversedGraph;
        }
    }
}