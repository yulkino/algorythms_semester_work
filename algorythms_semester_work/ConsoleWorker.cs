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
            Clear();
            WriteLine("What do you want?\n" +
                "1. Random graph\n" +
                "2. Random network of routers and station\n" +
                "3. Kruskal's Algorythm with random graph\n" +
                "4. Kruskal's Algorythm with random network of routers and station\n" +
                "5. Reverse Delete Algorythm with random graph\n" +
                "6. Reverse Delete Algorythm random network of routers and station\n");
            var key = ReadKey();
            switch(key.Key)
            {
                case ConsoleKey.D1:
                    ShowRandomGraph();
                    break;
                case ConsoleKey.D2:
                    ShowShowNetwork();
                    break;
                case ConsoleKey.D3:
                    ShowKruskalsAlgorythm(new GraphWorker().BuildNewWeightGrahp(10));
                    break;
                case ConsoleKey.D4:
                    ShowKruskalsAlgorythm(new GraphWorker().CreateNetwork(6));
                    break;
                case ConsoleKey.D5:
                    ShowReverseDeleteAlgorythm(new GraphWorker().BuildNewWeightGrahp(10));
                    break;
                case ConsoleKey.D6:
                    ShowReverseDeleteAlgorythm(new GraphWorker().CreateNetwork(6));
                    break;
            };
        }

        void ShowRandomGraph()
        {
            Clear();
            var graph = new GraphWorker().BuildNewWeightGrahp(10);
            WriteLine(graph);
            ReturnIntoStartWindow();
        }

        void ShowShowNetwork()
        {
            Clear();
            var network = new GraphWorker().CreateNetwork(4);
            WriteLine(network);
            ReturnIntoStartWindow();
        }

        void ShowKruskalsAlgorythm(WeightedGraph network)
        {
            Clear();
            var alg = new Algorythms();
            WriteLine(network + "\n");
            WriteLine(alg.KruskalsAlgorythm(network));
            ReturnIntoStartWindow();
        }

        void ShowReverseDeleteAlgorythm(WeightedGraph graph)
        {
            Clear();
            var alg = new Algorythms();
            WriteLine(graph + "\n");
            WriteLine(alg.ReverseDeleteAlgorythm(graph));
            ReturnIntoStartWindow();
        }

        void ReturnIntoStartWindow()
        {
            var key = ReadKey();
            if (key.Key == ConsoleKey.Escape)
                StartProcessing();
        }
    }
}
