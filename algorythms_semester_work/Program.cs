using System;
using static System.Console;

namespace algorythms_semester_work
{
    class Program
    {
        static void Main(string[] args)
        {
            Check();
            //new ConsoleWorker().StartProcessing();
        }

        static void Check()
        {
            var graph = new WeightedGraph();
            graph.ConnectNodes("ONE", "TWO", 12);
            graph.AddNode(new Node("TREE"));
            graph.ConnectNodes("FOUR", "TREE", 89);
            graph.AddNode("FIVE");
            graph.ConnectNodes("ONE", "FOUR", 100);
            graph.ConnectNodes("ONE", "FOUR", 100);
            Write(graph);

            WriteLine();
            Write(graph.FindNode("ONE"));
            WriteLine();

            graph.RemoveNode("FIVE");
            WriteLine(graph);

            WriteLine();
            graph.RemoveNode("FOUR");
            WriteLine(graph);

            ReadKey();
        }
    }
}
