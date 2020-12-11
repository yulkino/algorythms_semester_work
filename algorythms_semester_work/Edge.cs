using System;
using System.Collections.Generic;
using System.Text;

namespace algorythms_semester_work
{
    public class Edge
    {
        public Node Node1 { get; private set;  }
        public Node Node2 { get; private set; }
        public int Weight { get; private set; }

        public Edge CreateConnection(Node node1, Node node2, int weight)
        {
            Node1 = node1;
            Node2 = node2;
            Weight = weight;
            return this;
        }

        public override string ToString()
        {
            return $"{Node1} connected with {Node2} with weight {Weight}";
        }
    }
}
