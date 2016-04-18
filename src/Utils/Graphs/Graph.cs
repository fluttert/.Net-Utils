using Fluttert.Utils.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fluttert.ChallengeUtils.Graphs
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
            _vertices = vertices;
            _edges = 0;
            _adjacencyList = new List<int>[vertices];
            for (int v = 0; v < vertices; v++)
            {
                _adjacencyList[v] = new List<int>();
            }
        }

        private readonly int _vertices;
        private int _edges;
        private List<int>[] _adjacencyList;

        #region IGraph methods
        /// <summary>
        /// Total amount of vertices in this graph
        /// </summary>
        /// <returns>integer, amount of vertices</returns>
        public int Vertices() => _vertices;

        /// <summary>
        /// Total amount of edges in this graph
        /// </summary>
        /// <returns>integer, amount of edges</returns>
        public int Edges() => _edges/2;

        public void AddEdge(int vertexFrom, int vertexTo)
        {
            _adjacencyList[vertexFrom].Add(vertexTo);
            _adjacencyList[vertexTo].Add(vertexFrom);
            _edges=+2;
        }

        /// <summary>
        /// Returns all vertices (id's) that are adjecent to this vertex
        /// </summary>
        /// <param name="vertex">id of vertex</param>
        /// <returns>List with ID's of connected vertices</returns>
        public IEnumerable<int> AdjecentVertices(int v) => _adjacencyList[v];

        #endregion IGraph methods

        /// <summary>
        /// Creates a deepcopy of this graph
        /// </summary>
        /// <returns>Graph</returns>
        public Graph Copy()
        {
            var copy = new Graph(Vertices());
            for (int v = 0; v < Vertices(); v++)
            {
                var edges = AdjecentVertices(v).ToList();
                for (int e = 0; e < edges.Count; e++) {
                    copy.AddEdge(v, edges[e]);
                }
            }
            return copy;
        }

        /// <summary>
        /// Standard representation of the directed graph
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{_vertices} vertices, {_edges} edges");
            for (int v = 0; v < _vertices; v++)
            {
                sb.AppendLine($"{v} connects to: {string.Join(" ", AdjecentVertices(v))}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Helper funtion to check whether or not a vertex is withing range
        /// </summary>
        /// <param name="vertexId"></param>
        /// <returns></returns>
        private bool IsVertexWithinBounds(int vertexId)
        {
            return vertexId>=0 && vertexId < Vertices();
        }
    }
}