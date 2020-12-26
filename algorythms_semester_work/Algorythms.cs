using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algorythms_semester_work
{
    class Algorythms
    {
        #region KruskalsAlgorythm
        public WeightedGraph KruskalsAlgorythm(WeightedGraph graph)
        {
            var result = new WeightedGraph();
            var unicEdges = graph.Nodes.SelectMany(x => x.Edges).Distinct().OrderBy(e => e.Weight).ToList();
            List<List<string>> sets = new List<List<string>>();
            PrimaryProcessing(sets, unicEdges, result);
            for (var i = 0; i < unicEdges.Count; i++)
            {
                if (!IsCycle(sets, unicEdges[i].Node1.Name, unicEdges[i].Node2.Name))
                {
                    result.ConnectNodes(unicEdges[i].Node1.Name, unicEdges[i].Node2.Name, unicEdges[i].Weight);
                    AddToSubSet(sets, unicEdges[i]);
                    unicEdges.Remove(unicEdges[i]);
                    i = -1;
                }
            }
            return result;
        }

        void AddToSubSet(List<List<string>> set, Edge edge)
        {
            bool wasAddedN1 = false;
            bool wasAddedN2 = false;
            for (var j = 0; j < set.Count; j++)
            {
                if (set[j].Contains(edge.Node1.Name))
                {
                    if (!set[j].Contains(edge.Node2.Name))
                    {
                        set[j].Add(edge.Node2.Name);
                        wasAddedN2 = true;
                    }
                }
                else if (set[j].Contains(edge.Node2.Name) && !wasAddedN2)
                {
                    if (!set[j].Contains(edge.Node1.Name))
                    {
                        set[j].Add(edge.Node1.Name);
                        wasAddedN1 = true;
                    }
                }
            }
            if (wasAddedN1 || wasAddedN2)
                CheckForConnectSubSet(set, edge.Node1.Name, edge.Node2.Name);
            if (!wasAddedN1 && !wasAddedN2)
            {
                var subset = new List<string>();
                set.Add(subset);
                subset.Add(edge.Node1.Name);
                subset.Add(edge.Node2.Name);
            }
        }

        void CheckForConnectSubSet(List<List<string>> set, string nameNode1, string nameNode2)
        {
            List<string> currentNodeSubSet = new List<string>();
            List<string> connectedNodeSubSet = new List<string>();
            for (var i = 0; i < set.Count; i++)
            {
                if (set[i].Contains(nameNode1) && !currentNodeSubSet.Any())
                    currentNodeSubSet = set[i];
                else if (set[i].Contains(nameNode2))
                    connectedNodeSubSet = set[i];
            }
            bool isConnected = false;
            for (var i = 0; i < connectedNodeSubSet.Count; i++)
            {
                if (!currentNodeSubSet.Contains(connectedNodeSubSet[i]))
                    currentNodeSubSet.Add(connectedNodeSubSet[i]);
                isConnected = true;
            }
            if (isConnected)
                set.Remove(connectedNodeSubSet);
        }

        void PrimaryProcessing(List<List<string>> set, List<Edge> unicEdges, WeightedGraph result)
        {
            for (var i = 0; i < unicEdges.Count; i++)
            {
                if (unicEdges[i].Node1.Name.Contains("Station"))
                {
                    result.ConnectNodes(unicEdges[i].Node1.Name, unicEdges[i].Node2.Name, unicEdges[i].Weight);
                    bool exists = false;
                    for (var j = 0; j <= set.Count - 1; j++)
                    {
                        if (set[j].Contains(unicEdges[i].Node2.Name))
                            exists = true;
                    }
                    if (!exists)
                    {
                        var subset = new List<string>();
                        set.Add(subset);
                        subset.Add(unicEdges[i].Node2.Name);
                    }
                    if (unicEdges[i].Node1.Name.Contains("Station"))
                    {
                        unicEdges.Remove(unicEdges[i]);
                        i = -1;
                    }
                }
            }
        }

        bool IsCycle(List<List<string>> set, string nameNode1, string nameNode2)
        {
            for (var i = 0; i < set.Count; i++)
                if (set[i].Contains(nameNode1) && set[i].Contains(nameNode2))
                    return true;
            return false;
        }
        #endregion

        public WeightedGraph ReverseDeleteAlgorythm(WeightedGraph graph)
        {
            var unicEdges = graph.Nodes
                .SelectMany(x => x.Edges)
                .Where(x => !x.Node1.Name.Contains("Station"))
                .Distinct()
                .OrderByDescending(e => e.Weight)
                .ToList();
            HashSet<string> setOfAllNameNode = new HashSet<string>();
            setOfAllNameNode = PrimaryInitialization(unicEdges, setOfAllNameNode);
            for(var i = 0; i < unicEdges.Count; i++)
            {
                var currentEdge = unicEdges[i];
                unicEdges.Remove(unicEdges[i]);
                graph.Disconnect(currentEdge);
                if (IsNotConnectivity(graph, setOfAllNameNode))
                    graph.ConnectNodes(currentEdge.Node1.Name, currentEdge.Node2.Name, currentEdge.Weight);
                i = -1;
            }
            return graph;
        }

        bool IsNotConnectivity(WeightedGraph graph, HashSet<string> setOfAllNameNode)
        {
            var countEdgesInGraph = graph.Nodes
                .SelectMany(x => x.Edges)
                .Where(x => !x.Node1.Name.Contains("Station"))
                .Distinct()
                .Count();
            var setCurrentNames = graph.Nodes
                .SelectMany(x => x.Edges)
                .Where(x => !x.Node1.Name.Contains("Station"))
                .SelectMany(edge => new List<string>() { edge .Node1.Name, edge.Node2.Name })
                .Distinct();
            if (countEdgesInGraph < setCurrentNames.Count() - 1)
                return true;
            foreach (var name in setOfAllNameNode)
                if (!setCurrentNames.Contains(name))
                    return true;
            return false;
        }

        public HashSet<string> PrimaryInitialization(List<Edge> unicEdges,HashSet<string> setOfAllNameNode)
        {
            foreach (var e in unicEdges)
            {
                setOfAllNameNode.Add(e.Node1.Name);
                setOfAllNameNode.Add(e.Node2.Name);
            }
            return setOfAllNameNode;
        }
    }
}
