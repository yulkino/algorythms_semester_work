using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorythms_semester_work
{
    public class WeightedGraph
    {
        public List<Node> Nodes { get; private set; }
        
        public WeightedGraph()
        {
            Nodes = new List<Node>();
        }

        public void AddNode(string nameNode) 
            => AddNode(new Node(nameNode));

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public void ConnectNodes(string nodeName1, string nodeName2, int weight) 
            => ConnectNodes(
                CheckNodeInGraph(nodeName1) ? FindNode(nodeName1) : new Node(nodeName1), 
                CheckNodeInGraph(nodeName2) ? FindNode(nodeName2) : new Node(nodeName2), 
                weight);

        public void ConnectNodes(Node node1, Node node2, int weight)
        {
            if (!CheckNodeInGraph(node1))
                Nodes.Add(node1);
            if (!CheckNodeInGraph(node2))
                Nodes.Add(node2);
            node1.ConnectNode(node2, weight);
        }


        public bool CheckNodeInGraph(Node node)
            => Nodes.Select(n => n.Name).Contains(node?.Name);

        public bool CheckNodeInGraph(string nodeName)
            => Nodes.Select(n => n.Name).Contains(nodeName);

        Node FindNode(Node node) 
            => FindNode(node?.Name);

        public Node FindNode(string nameNode)
        {
            if (nameNode == null) return null;
            foreach (var n in Nodes)
            {
                if (nameNode.CompareTo(n.Name) == 0)
                    return n;
            }
            return null;
        }

        public string ShowFindNode(string nameNode) 
            => ShowFindNode(FindNode(nameNode));

        public string ShowFindNode(Node node)
        {
            string result = "";
            foreach (var n in node.Edges)
                result += $"{n.Node1} connected with {n.Node2}\n";
            return result;
        }

        public void RemoveNode(string name) 
            => RemoveNode(FindNode(name));

        public void RemoveNode(Node node)
        {
            node.ReconnectNode();
        }

        public override string ToString()
        {
            string result = "";
            foreach (var n in Nodes)
            {
                if (n.Edges.Any())
                    foreach (var e in n.Edges)
                        result += $"{e}\n";
                else
                    result += $"{n.Name} don't have any connections\n";
            }
            return result;
        }
    }
}
