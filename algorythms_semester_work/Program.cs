using System;
using static System.Console;

namespace algorythms_semester_work
{
    class Program
    {
        static void Main(string[] args)
        {
            var network = Check(6);
            WriteLine(new Algorythm().KruskalsAlgorythm(network));
            ReadKey();
            //new ConsoleWorker().StartProcessing();
        }

        static WeightedGraph Check(int countNode)
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
            for (var i = 0; i < 5; i++)
            {
                if (!network.CheckNodeInGraph("Station_" + i))
                    network.AddNode("Station_" + i);
            }
            //network.ConnectNodes("Router_" + 0, "Router_" + 5, 50);
            //network.ConnectNodes("Router_" + 1, "Router_" + 4, 61);
            //network.ConnectNodes("Router_" + 3, "Router_" + 4, 76);
            //network.ConnectNodes("Router_" + 5, "Router_" + 4, 112);
            //network.ConnectNodes("Router_" + 1, "Router_" + 5, 139);
            //network.ConnectNodes("Router_" + 2, "Router_" + 5, 141);
            //network.ConnectNodes("Router_" + 0, "Router_" + 4, 226);
            //network.ConnectNodes("Router_" + 2, "Router_" + 0, 279);
            //network.ConnectNodes("Router_" + 2, "Router_" + 3, 283);
            //network.ConnectNodes("Router_" + 0, "Router_" + 3, 318);
            //network.ConnectNodes("Router_" + 1, "Router_" + 2, 398);
            //network.ConnectNodes("Router_" + 2, "Router_" + 4, 451);
            //network.ConnectNodes("Router_" + 3, "Router_" + 5, 468);
            //network.ConnectNodes("Router_" + 0, "Router_" + 1, 478);
            //network.ConnectNodes("Router_" + 1, "Router_" + 3, 486);
            network.ConnectNodes("Station_" + 0, "Router_" + 0, 5);
            network.ConnectNodes("Station_" + 1, "Router_" + 1, 6);
            network.ConnectNodes("Station_" + 2, "Router_" + 3, 2);
            network.ConnectNodes("Station_" + 3, "Router_" + 5, 7);
            network.ConnectNodes("Station_" + 4, "Router_" + 2, 8);
            return (network);;
        }
    }
}
