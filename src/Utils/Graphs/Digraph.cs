using System.Collections.Generic;
using System.Text;

namespace Fluttert.Utils.Tree
{
    internal class Digraph
    {
        public Digraph(int vertices)
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

        public int Vertices => _vertices;
        public int Edges => _edges;

        public void AddEdge(int v, int w)
        {
            _adjacencyList[v].Add(w);
            _edges++;
        }

        public IEnumerable<int> Adjacent(int v) => _adjacencyList[v];

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine ("{_vertices} vertices, {_edges} edges");
            for (int v = 0; v < _vertices; v++)
            {
                sb.AppendLine($"{v} connects to: {string.Join(" ", Adjacent(v))}");
            }

            return sb.ToString();
        }

        public Digraph Reverse() {
            var reversedGraph = new Digraph(_vertices);
            for (int v = 0; v < _vertices; v++)
            {
                foreach (var w in Adjacent(v))
                {
                    reversedGraph.AddEdge(w, v);
                }
            }
            return reversedGraph;
        }
    }
}