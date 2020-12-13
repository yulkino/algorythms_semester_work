using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static System.Console;

namespace algorythms_semester_work
{
    class ConsoleWorker
    {
        public void StartProcessing()
        {
            var graph = BuildNewWeightGrahp(5);
            WriteLine(graph);
            ReadKey();
        }

        WeightedGraph BuildNewWeightGrahp(int countNode)
        {
            var weightGraph = new WeightedGraph();
            for (var i = 0; i < countNode; i++)
            {
                if(!weightGraph.CheckNodeInGraph(i.ToString()))
                    weightGraph.AddNode(i.ToString());
                while(new Random().Next(0, 2) == 1)
                {
                    weightGraph.ConnectNodes(i.ToString(), RandomNode(i, 0, countNode - 1).ToString(), new Random().Next(0, 501));
                }
            }
            return weightGraph;
        }



        public int RandomNode(int node, int min, int max)
        {
            int a;
            return (a = new Random().Next(min, max)) == node ? RandomNode(node, min, max) : a;
        }
    }
}
