using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class AStar
{

    [Test]
    public void AStarSimplePasses()
    {
        Node start = PathFindingGraph.getStart();
        Node end = PathFindingGraph.getEnd();
        List<Node> closeList = PathFindingGraph.generateGraph();
        List<Node> openList = new List<Node>();
        // PathFindingGraph.Crawl(closeList, start, end, openList, start);
    }

}