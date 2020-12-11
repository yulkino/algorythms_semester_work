using System;
using System.Collections.Generic;
using System.Linq;
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
            for(var e = 0; e < Edges.Count; e++)
                Edges.Remove(Edges[e]);
        }

        public override string ToString()
        {
            var result = "";
            if (Edges.Any())
                foreach (var e in Edges)
                    result += $"{Name}: {e} \n";
            else
                result += $"{Name} single node \n";
            return result;
        }
    }
}
