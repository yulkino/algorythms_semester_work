using System;
using System.Collections.Generic;
using System.Text;

namespace algorythms_semester_work
{
    public class Node
    {
        public string Name { get; private set; }
        public List<Edge> Edges { get; private set; }

        public Node(string nameNode)
        {
            Name = nameNode;
            Edges = new List<Edge>();
        }

        public void ConnectNode(Node node, int weight)
        {
            var edge = new Edge().CreateConnection(this, node, weight);
            Edges.Add(edge);
            node.Edges.Add(edge);
        }

        public void ReconnectNode()
        {
            foreach (var edge in Edges)
                Edges.Remove(edge);
        }

        public override string ToString() => Name;
    }
}
