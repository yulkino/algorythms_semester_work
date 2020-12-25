using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algorythms_semester_work
{
    class GraphWorker
    {
        public WeightedGraph BuildNewWeightGrahp(int countNode)
        {
            var weightGraph = new WeightedGraph();
            for (var i = 0; i < countNode; i++)
            {
                if (!weightGraph.CheckNodeInGraph("Node_" + i))
                    weightGraph.AddNode("Node_" + i);
                while (new Random().Next(0, 2) == 1)
                {
                    weightGraph.ConnectNodes("Node_" + i, "Node_" + RandomNode(i, 0, countNode - 1), new Random().Next(0, 501));
                }
            }
            return weightGraph;
        }

        int RandomNode(int node, int min, int max)
        {
            int a;
            return (a = new Random().Next(min, max)) == node ? RandomNode(node, min, max) : a;
        }

        public WeightedGraph CreateNetwork(int countNode)
        {
            var network = new WeightedGraph();
            for (var i = 0; i < countNode; i++)
            {
                if (!network.CheckNodeInGraph("Router_" + i))
                    network.AddNode("Router_" + i);
                for (var j = 0; j < countNode; j++)
                    if (i != j)
                        network.ConnectNodes("Router_" + i, "Router_" + j, new Random().Next(0, 501));
            }
            var countStation = new Random().Next(4, 11);
            for (var i = 0; i < countStation; i++)
            {
                if (!network.CheckNodeInGraph("Station_" + i))
                    network.AddNode("Station_" + i);
                network.ConnectNodes("Station_" + i, "Router_" + new Random().Next(0, countNode), new Random().Next(0, 501));
            }
            return network;
        }

    }
}
