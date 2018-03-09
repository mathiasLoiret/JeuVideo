using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

    public Transform victoryPic;

	// Use this for initialization
	void Start () {
        victoryPic.GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void victory()
    {
        victoryPic.GetComponent<Renderer>().enabled = true;
    }

    internal void hadCollected(string name, int v)
    {
       // Debug.Log("collect : " + name + " - " + v);
    }
}
