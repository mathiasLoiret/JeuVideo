using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folowPoulet : MonoBehaviour {

    public Transform cibleTr;
    public float percentToGoByFrame;
    public float finalPrecision;

    private Transform tr;
    private Vector3 folowDirection;

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
        folowDirection = new Vector3(0,0,0);

        if (percentToGoByFrame > 1)
            percentToGoByFrame = 1f;
        if (percentToGoByFrame <= 0)
            percentToGoByFrame = 0.01f;
        if (finalPrecision < 0)
            finalPrecision = 0f;
    }
	
	// Update is called once per frame    
	void Update () {
        if (System.Math.Abs(cibleTr.position.x - tr.position.x) > finalPrecision)
            folowDirection.x = (cibleTr.position.x - tr.position.x) * percentToGoByFrame;
        else
            folowDirection.x = 0;

        if (System.Math.Abs(cibleTr.position.y - tr.position.y) > finalPrecision)
            folowDirection.y = (cibleTr.position.y - tr.position.y) * percentToGoByFrame;
        else
            folowDirection.y = 0;

        tr.position += new Vector3(folowDirection.x, folowDirection.y, 0);
        //tr.position = new Vector3(cibleTr.position.x, cibleTr.position.y, tr.position.z);
    }
}

// distance *01