using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShowHideTiles : MonoBehaviour {
	public GameObject tileMap;
	// Use this for initialization
	void Start () {
		
	}
	
 private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
			if(tileMap.GetComponent<TilemapRenderer>().enabled ){
				tileMap.GetComponent<TilemapRenderer>().enabled = false;
			}else{
				tileMap.GetComponent<TilemapRenderer>().enabled = true;
			}

        }
            
    }
}
