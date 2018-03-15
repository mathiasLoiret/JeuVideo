using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCam : MonoBehaviour {

	public float vitesse;
	public GameObject  player;

    private float freezCountdown;

    // Use this for initialization
    void Start()
    {
        freezCountdown = 0;
    }

    // Update is called once per frame
    void Update () {
        freezCountdown -= Time.deltaTime;
        if(freezCountdown < 0)
        {
            this.transform.position = player.transform.position + new Vector3(Input.GetAxis("Horizontal") * vitesse, 0, 0);
        }

	}

    internal void freez(float v)
    {
        freezCountdown = v;
    }
}
