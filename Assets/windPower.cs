using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windPower : MonoBehaviour {

    public Transform tr;
    private CircleCollider2D cc;
    private float windPowerTimer;

    public Sprite[] envole1_sprite;

    public Transform target_tr;
    private SpriteRenderer target_sr;

    public float powerDuration;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CircleCollider2D>();
        tr = GetComponent<Transform>();
        target_sr = target_tr.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (windPowerTimer < 0)
        {
            //cc.enabled = false;
            target_tr.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            windPowerTimer--;
            if (windPowerTimer > powerDuration / 2)
                target_sr.sprite = envole1_sprite[0];
            else
                target_sr.sprite = envole1_sprite[1];

            target_tr.GetComponent<Renderer>().enabled = true;
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
        //cc.enabled = true;
        windPowerTimer = powerDuration;
        //target_sr.transform.position = tr.position + new Vector3(0,-1,0);
    }
}
