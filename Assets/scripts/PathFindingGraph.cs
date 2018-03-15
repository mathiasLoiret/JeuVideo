using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    
    public Node(float X, float Y, float C)
    {
        this.x = X;
        this.y = Y;
        this.h = 0f;
        this.c = C;
    }

    public bool Equals( Node other )
    {
        return this.x == other.x && this.y == other.y;
    }
}

public class PathFindingGraph
{
    public static Vector3Int vect3;
    public static bool isBlock;

    public static List<Node> Crawl(List<Node> closeList, Node start, Node end, List<Node> openList, Node realStart, Tilemap floorTilemap, Tilemap wallTilemap, Tilemap stairsTilemap)
    {
        if(isBlocked(end.x, end.y, floorTilemap, wallTilemap, stairsTilemap)){
            return new List<Node>();
        }

        if(openList.Count > 0){
            openList.ForEach(delegate(Node openNode){
                if(openNode.x == start.x && openNode.y == start.y){
                    closeList.Add(openNode);
                    openList.Remove(openNode);
                }
            });
        }

        List<Node> nearNodes = new List<Node>(){
            new Node(start.x - 1, start.y -1, 1.4f+start.c),
            new Node(start.x, start.y - 1, 1f+start.c),
            new Node(start.x + 1, start.y - 1, 1.4f+start.c),
            new Node(start.x + 1, start.y, 1f+start.c),
            new Node(start.x + 1, start.y + 1, 1.4f+start.c),
            new Node(start.x, start.y + 1, 1f+start.c),
            new Node(start.x - 1, start.y + 1, 1.4f+start.c),
            new Node(start.x - 1, start.y, 1f+start.c)
        };

        nearNodes.ForEach(delegate(Node nearNode){
            if(nearNode.c != 99999 && isBlocked(nearNode.x, nearNode.y, floorTilemap, wallTilemap, stairsTilemap)){
                nearNode.c = 99999;
            }
            if(!closeList.Contains(nearNode) && !openList.Contains(nearNode)){
                nearNode.h = getHeuristic(nearNode, end);
                        
                openList.Add(nearNode);
            }
        });
        
        Node startNode = openList.OrderBy(node => node.c+node.h).ToList().First();

        if(startNode.x == end.x && startNode.y == end.y){
            List<Node> result = new List<Node>();

            List<Node> realEndNode = closeList.OrderBy(node => node.c+node.h).ToList();

            return getWay(realEndNode, end, realStart, 0, result, floorTilemap, wallTilemap, stairsTilemap);
        }
        else{
            return Crawl(closeList, startNode, end, openList, realStart, floorTilemap, wallTilemap, stairsTilemap);
        }
    }

    //calculate the distance between two points
    public static float getHeuristic(Node start, Node end)
    {
        return Convert.ToSingle(Math.Sqrt(Math.Pow(end.x - start.x, 2)+Math.Pow(end.y - start.y, 2)));
    }

    public static List<Node> getWay(List<Node> closeList, Node end, Node start, int i, List<Node> result, Tilemap floorTilemap, Tilemap wallTilemap, Tilemap stairsTilemap)
    {
        List<Node> nearNodes = new List<Node>(){
            new Node(end.x - 1, end.y -1),
            new Node(end.x, end.y - 1),
            new Node(end.x + 1, end.y - 1),
            new Node(end.x + 1, end.y),
            new Node(end.x + 1, end.y + 1),
            new Node(end.x, end.y + 1),
            new Node(end.x - 1, end.y + 1),
            new Node(end.x - 1, end.y)
        };

        if(nearNodes.Contains(start)){
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

        return getWay(closeList, result[i], start, i+1, result, floorTilemap, wallTilemap, stairsTilemap);        
    }

    //check if the block in position x, y is floor wall or stairs
    public static bool isBlocked(float x, float y, Tilemap floorTilemap, Tilemap wallTilemap, Tilemap stairsTilemap)
    {
        if(vect3.x == x && vect3.y == y){
            return isBlock;
        }
        else{
            vect3.x = (int)x-1;
            vect3.y = (int)y;
        }
        
        if (floorTilemap.GetTile(vect3) != null){
            isBlock = true;
            return true;
        }
        else if (wallTilemap.GetTile(vect3) != null){
            isBlock = true;            
            return true;
        }
        else if (stairsTilemap.GetTile(vect3) != null){
            isBlock = true;            
            return true;
        }
        else{
            isBlock = false;            
            return false;
        }
    }
}