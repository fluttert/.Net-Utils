using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluttert.Utils.Graphs
{
    /// <summary>
    /// Undirected graph
    /// </summary>
    /// <remarks>This is inspired on the book Algorithms 4th edition by Sedgewick & Wayne</remarks>
    public class Graph : IGraph
    {
        public Graph(int vertices)
        {
            if (vertices < 0) { throw new ArgumentOutOfRangeException("No negative amount of vertices can exist"); }
            this.vertices = vertices;
            edges = 0;
            adjacencyList = new List<int>[vertices];
            addedEdges = new List<int[]>();
            for (int v = 0; v < vertices; v++)
            {
                adjacencyList[v] = new List<int>();
            }
        }

        private readonly int vertices;
        private readonly List<int>[] adjacencyList;
        private readonly List<int[]> addedEdges;
        private int edges;

        #region IGraph methods

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

        /// <summary>
        /// Adds an edge from a vertex to another vertex (can be the same)
        /// </summary>
        /// <param name="vertexFrom">Id of vertex where the edge starts</param>
        /// <param name="vertexTo">Id of vertex where the edge ends</param>
        public void AddEdge(int vertexFrom, int vertexTo)
        {
            addedEdges.Add(new int[] { vertexFrom, vertexTo });
            adjacencyList[vertexFrom].Add(vertexTo);

            // add the edge the ohter way around; only if the edge is not a self-loop
            if (vertexFrom != vertexTo)
            {
                adjacencyList[vertexTo].Add(vertexFrom);
            }
            edges++;
        }

        /// <summary>
        /// Returns all vertices (id's) that are adjecent to this vertex
        /// </summary>
        /// <param name="vertex">id of vertex</param>
        /// <returns>List with ID's of connected vertices</returns>
        public IEnumerable<int> AdjecentVertices(int vertex) => adjacencyList[vertex];

        #endregion IGraph methods

        /// <summary>
        /// Creates a deepcopy of this graph
        /// </summary>
        /// <returns>Graph</returns>
        public Graph DeepCopy()
        {
            var copy = new Graph(Vertices());
            for (int e = 0; e < addedEdges.Count; e++)
            {
                copy.AddEdge(addedEdges[e][0], addedEdges[e][1]);
            }
            return copy;
        }

        /// <summary>
        /// Standard representation of the directed graph
        /// </summary>
        /// <returns></returns>
        public override string ToString() => GraphUtil.Stringify(this);

        /// <summary>
        /// Helper funtion to check whether or not a vertex is withing range
        /// </summary>
        /// <param name="vertexId"></param>
        /// <returns></returns>
        private bool IsVertexWithinBounds(int vertexId)
        {
            return vertexId >= 0 && vertexId < Vertices();
        }
    }
}