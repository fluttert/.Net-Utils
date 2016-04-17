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
            _vertices = vertices;
            _edges = 0;
            _adjacencyList = new List<int>[vertices];
            for (int v = 0; v < vertices; v++)
            {
                _adjacencyList[v] = new List<int>();
            }
        }

        private int _vertices;
        private int _edges;
        private List<int>[] _adjacencyList;

        /// <summary>
        /// Total amount of vertices in this graph
        /// </summary>
        /// <returns>integer, amount of vertices</returns>
        public int Vertices() => _vertices;

        /// <summary>
        /// Total amount of edges in this graph
        /// </summary>
        /// <returns>integer, amount of edges</returns>
        public int Edges() => _edges;

        public void AddEdge(int v, int w)
        {
            _adjacencyList[v].Add(w);
            _edges++;
        }

        /// <summary>
        /// Returns all vertices (id's) that are adjecent to this vertex
        /// </summary>
        /// <param name="vertex">id of vertex</param>
        /// <returns>List with ID's of connected vertices</returns>
        public IEnumerable<int> AdjecentVertices(int v) => _adjacencyList[v];

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
        /// Reverse the directed edges in the graph
        /// </summary>
        /// <returns></returns>
        public DirectedGraph Reverse()
        {
            var reversedGraph = new DirectedGraph(_vertices);
            for (int v = 0; v < _vertices; v++)
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