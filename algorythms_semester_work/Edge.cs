using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace algorythms_semester_work
{
    public class Edge : IEquatable<Node>
    {
        public Node Node1 { get; private set; }
        public Node Node2 { get; private set; }
        public int Weight { get; private set; }

        public Edge(Node node1, Node node2, int weight)
        {
            Node1 = node1;
            Node2 = node2;
            Weight = weight;
        }

        public override int GetHashCode()
        {
            return Node1.GetHashCode() + Node2.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public bool Equals([AllowNull] Node other)
        {
            return GetHashCode() == other.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Node1.Name} \t<--{Weight}-->\t{Node2.Name}";
        }
    }
}
