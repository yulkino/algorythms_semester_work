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
            WriteLine("What do you want:\n" +
                "1. Random graph\n" +
                "2. Network of routers");
            var key = ReadKey();
            switch(key.Key)
            {
                case ConsoleKey.D1:
                    ShowRandomGraph();
                    break;
                case ConsoleKey.D2:
                    ShowShowNetwork();
                    break;
            };
        }

        public void ShowRandomGraph()
        {
            Clear();
            var graphWorker = new GraphWorker();
            var graph = graphWorker.BuildNewWeightGrahp(10);
            WriteLine(graph);
            ReturnIntoStrtWindow();
        }

        public void ShowShowNetwork()
        {
            Clear();
            var graphWorker = new GraphWorker();
            var network = graphWorker.CreateNetwork(4);
            WriteLine(network);
            ReturnIntoStrtWindow();
        }

        public void ReturnIntoStrtWindow()
        {
            var key = ReadKey();
            if (key.Key == ConsoleKey.Escape)
                StartProcessing();
        }
    }
}
