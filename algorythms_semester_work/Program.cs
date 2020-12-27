using System;
using static System.Console;

namespace algorythms_semester_work
{
    class Program
    {
        static void Main(string[] args)
        {
            new ConsoleWorker().StartProcessing();
            //var network = new GraphWorker().CreateNetwork(6);
            //WriteLine(network);
            //WriteLine(new Algorythms().ReverseDeleteAlgorythm(network));
            //ReadKey();
            //new ConsoleWorker().StartProcessing();
        }

        WeightedGraph CreateNewNetwork(int countNode)
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
            //network.ConnectNodes("Router_" + 1, "Router_" + 4, 60);
            //network.ConnectNodes("Router_" + 3, "Router_" + 4, 76);
            //network.ConnectNodes("Router_" + 5, "Router_" + 4, 112);
            //network.ConnectNodes("Router_" + 1, "Router_" + 5, 140);
            //network.ConnectNodes("Router_" + 2, "Router_" + 5, 150);
            //network.ConnectNodes("Router_" + 0, "Router_" + 4, 200);
            //network.ConnectNodes("Router_" + 2, "Router_" + 0, 270);
            //network.ConnectNodes("Router_" + 2, "Router_" + 3, 300);
            //network.ConnectNodes("Router_" + 0, "Router_" + 3, 340);
            //network.ConnectNodes("Router_" + 1, "Router_" + 2, 400);
            //network.ConnectNodes("Router_" + 2, "Router_" + 4, 450);
            //network.ConnectNodes("Router_" + 3, "Router_" + 5, 470);
            //network.ConnectNodes("Router_" + 0, "Router_" + 1, 500);
            //network.ConnectNodes("Router_" + 1, "Router_" + 3, 560);


            network.ConnectNodes("Station_" + 0, "Router_" + 0, 5);
            network.ConnectNodes("Station_" + 1, "Router_" + 1, 6);
            network.ConnectNodes("Station_" + 2, "Router_" + 3, 2);
            network.ConnectNodes("Station_" + 3, "Router_" + 5, 7);
            network.ConnectNodes("Station_" + 4, "Router_" + 2, 8);
            return network;
        }
    }
}
