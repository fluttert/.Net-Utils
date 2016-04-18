using Fluttert.Utils.Graphs;
using System.Linq;
using System.Text;

namespace Fluttert.Utils.Graphs
{
    internal class GraphUtil
    {
        internal static string Stringify(IGraph graph)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{graph.Vertices()} vertices, {graph.Edges()} edges");
            for (int v = 0; v < graph.Vertices(); v++)
            {
                sb.AppendLine($"Vertex {v} connects to: {string.Join(" ", graph.AdjecentVertices(v))}");
            }
            return sb.ToString();
        }
    }
}