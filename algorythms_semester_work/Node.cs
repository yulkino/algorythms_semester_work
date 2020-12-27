using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorythms_semester_work
{
    public class Node
    {
        public string Name { get; private set; }
        public HashSet<Edge> Edges { get; private set; }

        public Node(string nameNode)
        {
            Name = nameNode;
            Edges = new HashSet<Edge>();
        }

        public void ConnectNode(Node node, int weight)
        {
            var edge = new Edge(this, node, weight);
            if (!Edges.Contains(edge))
            {
                Edges.Add(edge);
                node.Edges.Add(edge);
            }
        }

        public void ReconnectNode()
        {
            while(Edges.Any())
                Edges.Remove(Edges.First());
        }
        
        public void RemoveEdge(Node node)
        {
            Edges.RemoveWhere(edge => edge.Node1 == node || edge.Node2 == node);
        }

        public override string ToString()
        {
            var result = "";
            if (Edges.Any())
                foreach (var e in Edges)
                    result += $"{Name}:\t {e} \n";
            else
                result += $"{Name}\t single node \n";
            return result;
        }
    }
}
