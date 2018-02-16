using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folowPoulet : MonoBehaviour {

    public Transform cibleTr;
    private Transform tr;


    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        tr.position = new Vector3(cibleTr.position.x, cibleTr.position.y, tr.position.z);
	}
}
