using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Node: IEquatable<Node>
{
    public float x, y, c, h;

    public Node(float X, float Y)
    {
        this.x = X;
        this.y = Y;
        this.h = 0f;
        this.c = 0f;
    }

    public bool Equals( Node other )
    {
        // Would still want to check for null etc. first.
        return this.x == other.x && 
               this.y == other.y;
    }
}

public static class PathFindingGraph
{
    public static List<Node> generateGraph()
    {
        Node A = new Node(3, 1);
        A.c = 99999;
        Node B = new Node(3, 2);
        B.c = 99999;        
        Node C = new Node(4, 2);
        C.c = 99999;        
        Node D = new Node(5, 2);
        D.c = 99999;        
        Node E = new Node(6, 2);
        E.c = 99999;        
        Node F = new Node(7, 2);
        F.c = 99999;        

        List<Node> graph = new List<Node>();
        graph.Add(A);    
        graph.Add(B);
        graph.Add(C);    
        graph.Add(D);    
        graph.Add(E);    
        graph.Add(F);   

        return graph;
    }

    public static Node getStart()
    {
        Node S = new Node(7, 4);        
        return S;
    }  
    
    public static Node getEnd()
    {
        Node Z = new Node(4, 1);        
        return Z;
    }

    public static void Crawl(List<Node> closeList, Node start, Node end, List<Node> openList, Node realStart)
    {
        if(openList.Count > 0){
            openList.ForEach(delegate(Node openNode){
                if(openNode.x == start.x && openNode.y == start.y){
                    closeList.Add(openNode);
                    openList.Remove(openNode);
                }
            });
        }

        List<Node> nearNodes = new List<Node>();
        Node NO = new Node(start.x - 1, start.y -1);
        NO.c = 1.4f+start.c;
        Node N = new Node(start.x, start.y - 1);
        N.c = 1f+start.c;
        Node NE = new Node(start.x + 1, start.y - 1);
        NE.c = 1.4f+start.c;
        Node E = new Node(start.x + 1, start.y);
        E.c = 1f+start.c;
        Node SE = new Node(start.x + 1, start.y + 1);
        SE.c = 1.4f+start.c;
        Node S = new Node(start.x, start.y + 1);
        S.c = 1f+start.c;
        Node SO = new Node(start.x - 1, start.y + 1);
        SO.c = 1.4f+start.c;
        Node O = new Node(start.x - 1, start.y);
        O.c = 1f+start.c;
        nearNodes.Add(NO);
        nearNodes.Add(N);
        nearNodes.Add(NE);
        nearNodes.Add(E);
        nearNodes.Add(SE);
        nearNodes.Add(S);
        nearNodes.Add(SO);
        nearNodes.Add(O);

        List<Node> tempNodes = new List<Node>();

        nearNodes.ForEach(delegate(Node nearNode){
            if(!closeList.Contains(nearNode) && !openList.Contains(nearNode)){
                nearNode.h = getHeuristic(nearNode, end);
                        
                tempNodes.Add(nearNode);
            }
        });
        
        tempNodes.ForEach(delegate(Node tempNode){
            // Debug.Log("positions :");
            // Debug.Log(tempNode.x);
            // Debug.Log(tempNode.y);
            openList.Add(tempNode);
        });
            
        Node startNode = openList.OrderBy(node => node.c+node.h).ToList().First();

        // Debug.Log("positions :");
        // Debug.Log(startNode.x);
        // Debug.Log(startNode.y);
        // Debug.Log(startNode.h);
        // Debug.Log(startNode.h+startNode.c);

        if(startNode.x == end.x && startNode.y == end.y){
            List<Node> result = new List<Node>();
            Debug.Log("end");

            List<Node> realEndNode = closeList.OrderBy(node => node.c+node.h).ToList();

            realEndNode.ForEach(delegate(Node toto){
                // Debug.Log("x y :");
                // Debug.Log(toto.x);
                // Debug.Log(toto.y);
                // Debug.Log("c + h :");
                // Debug.Log(toto.c + toto.h);
            });

            getWay(realEndNode, end, realStart, 0, result).ForEach(delegate(Node resultNode){
                // Debug.Log("x y :");
                // Debug.Log(resultNode.x);
                // Debug.Log(resultNode.y);
                // Debug.Log("c + h :");
                // Debug.Log(resultNode.c + resultNode.h);
            });
            return;
        }

        Crawl(closeList, startNode, end, openList, realStart);
    }

    public static float getHeuristic(Node start, Node end)
    {
        return Convert.ToSingle(Math.Sqrt(Math.Pow(end.x - start.x, 2)+Math.Pow(end.y - start.y, 2)));
    }

    public static List<Node> getWay(List<Node> closeList, Node end, Node start, int i, List<Node> result)
    {
        List<Node> nearNodes = new List<Node>();
        Node NO = new Node(end.x - 1, end.y -1);
        Node N = new Node(end.x, end.y - 1);
        Node NE = new Node(end.x + 1, end.y - 1);
        Node E = new Node(end.x + 1, end.y);
        Node SE = new Node(end.x + 1, end.y + 1);
        Node S = new Node(end.x, end.y + 1);
        Node SO = new Node(end.x - 1, end.y + 1);
        Node O = new Node(end.x - 1, end.y);
        nearNodes.Add(NO);
        nearNodes.Add(N);
        nearNodes.Add(NE);
        nearNodes.Add(E);
        nearNodes.Add(SE);
        nearNodes.Add(S);
        nearNodes.Add(SO);
        nearNodes.Add(O);

        if(nearNodes.Contains(start) || i == 100){
            return result;
        }

        nearNodes.ForEach(delegate(Node nearNode){
            if(closeList.Contains(nearNode)){
                int index = closeList.IndexOf(nearNode);

                Node node = closeList[index];
                closeList.Remove(node);
                if(result.Count < i+1){               
                    result.Add(node);
                }
                else if(result.Count == i+1){
                    if(result[i].c+result[i].h > node.c+node.h){
                        result[i] = node;
                    }
                }
            }
        });

        return getWay(closeList, result[i], start, i+1, result);        
    }
}