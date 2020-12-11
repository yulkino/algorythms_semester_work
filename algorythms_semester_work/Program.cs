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
            var g = new WeightedGraph();
            g.ConnectNodes("ONE", "TWO", 12);
            g.AddNode(new Node("TREE"));
            g.ConnectNodes("FOUR", "TREE", 89);
            g.AddNode("FIVE");
            g.ConnectNodes("ONE", "FOUR", 100);
            Write(g);

            WriteLine();
            Write(g.FindNode("ONE"));
            WriteLine();

            g.RemoveNode("FIVE");
            WriteLine(g);

            WriteLine();
            g.RemoveNode("FOUR");
            WriteLine(g);

            ReadKey();
        }
    }
}
