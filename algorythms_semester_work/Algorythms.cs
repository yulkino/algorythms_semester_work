using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algorythms_semester_work
{
    class Algorythms
    {
        #region KruskalsAlgorythm
        public WeightedGraph KruskalsAlgorythm(WeightedGraph graph) // Пусть S - станции , R - роутеры, тогда 
                                                                    //StR - ребра между станцией и роутером 
                                                                    //RtR - ребра между роутером и роутером
        {
            var result = new WeightedGraph();
            var unicEdges = graph.Nodes
                .SelectMany(x => x.Edges)
                .Distinct()
                .OrderBy(e => e.Weight)
                .ToList();                                                                                      //2E+E+ElogE+E => E+ElogE ---
            List<List<string>> sets = new List<List<string>>();
            PrimaryProcessing(sets, unicEdges, result);                                                         //E*V^2 + E^2 => E(V^2+E) ---
            if (unicEdges.Count < graph.Nodes.Count(n => n.Edges.Count > 1))                                    //V
                return graph;
            for (var i = 0; i < unicEdges.Count; i++)                                                           //RtR => RtR * R^2 + Rtr * R^2 + RtR * R + RtR * R => RtR(R^2 + R) ---
            {
                if (!IsCycle(sets, unicEdges[i].Node1.Name, unicEdges[i].Node2.Name))                           //R^2
                {
                    result.ConnectNodes(unicEdges[i].Node1.Name, unicEdges[i].Node2.Name, unicEdges[i].Weight); //1
                    AddToSubSet(sets, unicEdges[i]);                                                            //R^2+R
                    unicEdges.Remove(unicEdges[i]);                                                             //R
                    i--;                
                }
            }
            return result;                                                          //общая сложность : O(E * logE + E(V^2+E) + RtR(R^2 + R)) => O(E(logE + V^2 + E) + V + RtR(R^2 + R))
        }

        void AddToSubSet(List<List<string>> set, Edge edge)                 //R^2+R
        {
            bool wasAddedN1 = false;
            bool wasAddedN2 = false;
            for (var j = 0; j < set.Count; j++)                             // R => 4R^2 => R^2
            {
                if (set[j].Contains(edge.Node1.Name))                       //R
                {
                    if (!set[j].Contains(edge.Node2.Name))                  //R
                    {
                        set[j].Add(edge.Node2.Name);                        //1
                        wasAddedN2 = true;
                    }
                }
                else if (set[j].Contains(edge.Node2.Name) && !wasAddedN2)   //R
                {
                    if (!set[j].Contains(edge.Node1.Name))                  // R
                    {
                        set[j].Add(edge.Node1.Name);                        //1
                        wasAddedN1 = true;
                    }
                }
            }
            if (wasAddedN1 || wasAddedN2)
                CheckForConnectSubSet(set, edge.Node1.Name, edge.Node2.Name);//R^2+R
            if (!wasAddedN1 && !wasAddedN2)
            {
                var subset = new List<string>();
                set.Add(subset);                //1
                subset.Add(edge.Node1.Name);    //1
                subset.Add(edge.Node2.Name);    //1
            }
        }

        void CheckForConnectSubSet(List<List<string>> set, string nameNode1, string nameNode2) //3R^2+R^2+R => R^2+R
        {
            List<string> currentNodeSubSet = new List<string>();
            List<string> connectedNodeSubSet = new List<string>();
            for (var i = 0; i < set.Count; i++)                             //R =>
            {
                if (set[i].Contains(nameNode1) && !currentNodeSubSet.Any()) //R + R
                    currentNodeSubSet = set[i];
                else if (set[i].Contains(nameNode2))                        //R
                    connectedNodeSubSet = set[i];
            }
            bool isConnected = false;
            for (var i = 0; i < connectedNodeSubSet.Count; i++)             //R =>
            {
                if (!currentNodeSubSet.Contains(connectedNodeSubSet[i]))    //R
                    currentNodeSubSet.Add(connectedNodeSubSet[i]);          //1
                isConnected = true;
            }
            if (isConnected)
                set.Remove(connectedNodeSubSet);                            //R
        }

        void PrimaryProcessing(List<List<string>> set, List<Edge> unicEdges, WeightedGraph result) //EV^2+E^2
        {
            for (var i = 0; i < unicEdges.Count; i++)                                               //E => E(V*V+E) => EV^2+E^2
            {
                if (unicEdges[i].Node1.Edges.Count == 1) //если у вершины 1 ребро, то это станция   //1
                {
                    result.ConnectNodes(unicEdges[i].Node1.Name, unicEdges[i].Node2.Name, unicEdges[i].Weight);//1
                    bool exists = false;
                    for (var j = 0; j <= set.Count - 1; j++)                                        // V
                    {
                        if (set[j].Contains(unicEdges[i].Node2.Name))                               // V
                            exists = true;
                    }
                    if (!exists)
                    {
                        var subset = new List<string>();
                        set.Add(subset);                                                            //1
                        subset.Add(unicEdges[i].Node2.Name);                                        //1
                    }
                    unicEdges.Remove(unicEdges[i]);                                                 //E
                    i--;
                }
            }
        }

        bool IsCycle(List<List<string>> set, string nameNode1, string nameNode2)    //R^2+R^2 => R^2
        {
            for (var i = 0; i < set.Count; i++)                                     //R
                if (set[i].Contains(nameNode1) && set[i].Contains(nameNode2))       // R+R
                    return true;
            return false;
        }
        #endregion


        #region ReverseDeleteAlgorythm
        public WeightedGraph ReverseDeleteAlgorythm(WeightedGraph graph) //Условия теже, что и в прошлом алгоритме 
                                                                         //=> O(E+V + RtR + RtR(RtR + E + R^2)) => O(E + V + RtR(RtR + E + R^2))
        {
            var unicEdges = graph.Nodes                                 //=>E+V
                .SelectMany(x => x.Edges)                               //2E
                .Where(x => x.Node1.Edges.Count() != 1)                 //V
                .Distinct()                                             //E
                .OrderByDescending(e => e.Weight)                       //E
                .ToList();                                              //E
            if (unicEdges.Count < graph.Nodes.Count(n => n.Edges.Count > 1)) //V
                return graph;
            HashSet<string> setOfAllNameNode = new HashSet<string>();
            setOfAllNameNode = PrimaryInitialization(unicEdges, setOfAllNameNode); //=> RtR
            for(var i = 0; i < unicEdges.Count; i++) // RtR=> RtR(RtR + E + R^2)  
            {
                var currentEdge = unicEdges[i];
                unicEdges.Remove(unicEdges[i]); //RtR
                graph.Disconnect(currentEdge); //1
                if (IsNotConnectivity(graph, setOfAllNameNode)) //=> E + RtR + R ^ 2
                    graph.ConnectNodes(currentEdge.Node1.Name, currentEdge.Node2.Name, currentEdge.Weight); //1
                i--;
            }
            return graph;
        }

        bool IsNotConnectivity(WeightedGraph graph, HashSet<string> setOfAllNameNode) //=> E + RtR + RtR + RtR + R^2  => E + RtR + R^2
        {
            var edgeWithoutStation = graph.Nodes            //=>E
                .SelectMany(x => x.Edges)                   //E                            
                .Where(x => x.Node1.Edges.Count != 1);    //E
            var countEdgesInGraph = edgeWithoutStation.Distinct().Count(); //RtR + RtR => RtR
            var setCurrentNames = edgeWithoutStation
                .SelectMany(edge => new List<string>() { edge .Node1.Name, edge.Node2.Name }) //2RtR
                .Distinct();                                                                  //RtR
            if (countEdgesInGraph < setCurrentNames.Count() - 1)                              //RtR
                return true;
            foreach (var name in setOfAllNameNode)                  //R => R^2
                if (!setCurrentNames.Contains(name))                //R
                    return true;
            return false;
        }

        HashSet<string> PrimaryInitialization(List<Edge> unicEdges,HashSet<string> setOfAllNameNode) // => RtR
        {
            foreach (var e in unicEdges) //RtR
            {
                setOfAllNameNode.Add(e.Node1.Name);//1
                setOfAllNameNode.Add(e.Node2.Name);//1
            }
            return setOfAllNameNode;
        }
    }
    #endregion
}
