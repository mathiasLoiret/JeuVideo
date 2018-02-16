using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folowPoulet : MonoBehaviour {

    public Transform cibleTr;
    private Transform tr;
    private Vector3 folowDirection;

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
        folowDirection = new Vector3(0,0,0);

    }
	
	// Update is called once per frame    
	void Update () {
        if (System.Math.Abs(cibleTr.position.x - tr.position.x) > 0.5f)
            folowDirection.x = (cibleTr.position.x - tr.position.x) * 0.02f;
        else
            folowDirection.x = 0;

        if (System.Math.Abs(cibleTr.position.y - tr.position.y) > 0.5f)
            folowDirection.y = (cibleTr.position.y - tr.position.y) * 0.02f;
        else
            folowDirection.y = 0;

        tr.position += new Vector3(folowDirection.x, folowDirection.y, 0);
        //tr.position = new Vector3(cibleTr.position.x, cibleTr.position.y, tr.position.z);
    }
}

// distance *01