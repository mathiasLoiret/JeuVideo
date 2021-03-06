﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax  : MonoBehaviour {

    public Transform cibleTr;
    public float percentToGoByFrame;
    public float finalPrecision;
	public float scaleFactor = 1f;
    Vector3 targetPosition;

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
	void LateUpdate () {
        targetPosition = new Vector3(cibleTr.position.x * scaleFactor, 25, 0);
        if (System.Math.Abs(targetPosition.x - tr.position.x) > finalPrecision)
            folowDirection.x = (targetPosition.x - tr.position.x) * percentToGoByFrame;
        else
            folowDirection.x = 0;

        if (System.Math.Abs(targetPosition.y - tr.position.y) > finalPrecision)
            folowDirection.y = (targetPosition.y - tr.position.y) * percentToGoByFrame;
        else
            folowDirection.y = 0;

        tr.position += new Vector3(folowDirection.x, folowDirection.y, 0);
        //tr.position = new Vector3(cibleTr.position.x, cibleTr.position.y, tr.position.z);
    }
}

// distance *01