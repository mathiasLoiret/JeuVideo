﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windPower : MonoBehaviour {


    private CircleCollider2D cc;
    private float windPowerTimer;

    public Transform fire_ring_tr;

    public float powerDuration;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (windPowerTimer < 0)
        {
            cc.enabled = false;
            fire_ring_tr.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            windPowerTimer--;
            fire_ring_tr.GetComponent<Renderer>().enabled = true;
        }
            
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            other.GetComponent<Rigidbody2D>().velocity = 
                new Vector2((other.transform.position.x - this.transform.position.x) *10, 
                            (other.transform.position.y - this.transform.position.y) *10);
        }      
    }

    internal void go()
    {
        cc.enabled = true;
        windPowerTimer = powerDuration;
    }
}
