using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShowHideTiles : MonoBehaviour {
	public GameObject tileMap;
	// Use this for initialization
	private Collider2D collider;
	void Start () {
		collider = GetComponent<Collider2D>();
	}

	void Update()
	{
	
    }
	
	
	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player")
        {
       tileMap.GetComponent<TilemapRenderer>().enabled = false;
		}
    }


	void OnTriggerExit2D(Collider2D collision) {
		if (collision.tag == "Player")
        {
        tileMap.GetComponent<TilemapRenderer>().enabled = true;
		}
    }

}
