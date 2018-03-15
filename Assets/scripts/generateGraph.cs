using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Threading;

public class generateGraph : MonoBehaviour {

	public GameObject floor;
	public GameObject wall;
	public GameObject stairs;
	public GridLayout gridLayout;
	public GameObject chicken;
	
	
    private Transform tr;
    private Transform chickenTr;
	private List<Node> closeList;
	private List<Node> openList;
	private Node start;
	private Node end;
	private Vector3Int cellPosition;
	private Vector3Int chickenPosition;
	private List<Node> way;
	private List<Node> testWay;

    public float minFps = 60;
    private float deltaTime = 0.0f;
		
	

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
		chickenTr = chicken.GetComponent<Transform>();
		chickenTr.position = new Vector3(chickenTr.position.x, chickenTr.position.y+0.5f, chickenTr.position.z) ;

        cellPosition = gridLayout.WorldToCell(tr.position);
        chickenPosition = gridLayout.WorldToCell(chickenTr.position);

		start = new Node(cellPosition.x, cellPosition.y);
        end = new Node(chickenPosition.x, chickenPosition.y);
        closeList = new List<Node>();
        openList = new List<Node>();

		way = PathFindingGraph.Crawl(closeList, start, end, openList, start, floor.GetComponent<Tilemap>(), wall.GetComponent<Tilemap>(), stairs.GetComponent<Tilemap>());
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += Time.deltaTime;
        if ((deltaTime > 1 / minFps) && (start != end))
        {
			cellPosition = gridLayout.WorldToCell(tr.position);
        	chickenPosition = gridLayout.WorldToCell(new Vector3(chickenTr.position.x, chickenTr.position.y+0.5f, chickenTr.position.z));

			start = new Node(cellPosition.x, cellPosition.y);
			end = new Node(chickenPosition.x, chickenPosition.y);
			closeList = new List<Node>();
			openList = new List<Node>();

			testWay = PathFindingGraph.Crawl(closeList, start, end, openList, start, floor.GetComponent<Tilemap>(), wall.GetComponent<Tilemap>(), stairs.GetComponent<Tilemap>());

			if(testWay.Count > 0){
				way = testWay;
			}

			if(way.Count>0){
				Node node = way[way.Count-1];
				way.Remove(way[way.Count-1]);
				Vector3Int pos = new Vector3Int((int)node.x, (int)node.y, 0);
				Vector3Int worldPos = gridLayout.WorldToCell(pos);
				tr.position = worldPos;
			}
			
			deltaTime -= 1 / minFps;
		}
	}
}
