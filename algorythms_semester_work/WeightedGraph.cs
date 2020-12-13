using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorythms_semester_work
{
    public class WeightedGraph
    {
        public List<Node> Nodes { get; private set; }
        HashSet<string> keys = new HashSet<string>();
        
        public WeightedGraph()
        {
            Nodes = new List<Node>();
        }

        public void AddNode(string nameNode) 
            => AddNode(new Node(nameNode));

        public void AddNode(Node node)
        {
            if (!keys.Contains(node.Name))
            {
                Nodes.Add(node);
                keys.Add(node.Name);
            }
        }

        public void ConnectNodes(string nodeName1, string nodeName2, int weight)
            => ConnectNodes(
                FindNode(nodeName1) ?? new Node(nodeName1), 
                FindNode(nodeName2) ?? new Node(nodeName2), 
                weight);

        public void ConnectNodes(Node node1, Node node2, int weight)
        {
            if (!CheckNodeInGraph(node1))
                AddNode(node1);
            if (!CheckNodeInGraph(node2))
                AddNode(node2);
            node1.ConnectNode(node2, weight);
        }


        public bool CheckNodeInGraph(Node node)
            => keys.Contains(node?.Name);

        public bool CheckNodeInGraph(string nodeName)
            => keys.Contains(nodeName);

        public Node FindNode(Node node) 
            => FindNode(node?.Name);

        public Node FindNode(string nameNode)
        {
            if (nameNode != null && keys.Contains(nameNode))
               return Nodes.FirstOrDefault(node => node.Name == nameNode);
            else
                return null;
        }

        public string ShowFindNode(string nameNode) 
            => ShowFindNode(FindNode(nameNode));

        public string ShowFindNode(Node node)
        {
            string result = "";
            foreach (var n in node.Edges)
                result += $"{n.Node1} connected with {n.Node2} \n";
            return result;
        }

        public void RemoveNode(string name) 
            => RemoveNode(FindNode(name));

        public void RemoveNode(Node node)
        {
            RemoveEdgesOfIncidentsNodes(node);
            node.ReconnectNode();
            Nodes.Remove(node);
            keys.Remove(node.Name);
        }

        void RemoveEdgesOfIncidentsNodes(Node node)
        {
            List<Node> incidentsNodes = new List<Node>();
            foreach (var e in node.Edges)
                if (e.Node1 == node)
                    incidentsNodes.Add(e.Node2);
                else
                    incidentsNodes.Add(e.Node1);
            foreach (var n in incidentsNodes)
                n.RemoveEdge(node);
        }

        public override string ToString()
        {
            string result = "";
            foreach (var n in Nodes)
                result += n;
            return result;
        }
    }
}
