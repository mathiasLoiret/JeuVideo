using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class generateGraph : MonoBehaviour {

	public GameObject floor;
	public GameObject wall;

	// Use this for initialization
	void Start () {
		// TileBase tile = floor.GetComponent<Tilemap>().GetTile(floor.GetComponent<Tilemap>().worldToCell());
        Node start = new Node(26, 26);
        Node end = new Node(36, 36);
        List<Node> closeList = new List<Node>();
        List<Node> openList = new List<Node>();
        PathFindingGraph.Crawl(closeList, start, end, openList, start, floor.GetComponent<Tilemap>(), wall.GetComponent<Tilemap>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
