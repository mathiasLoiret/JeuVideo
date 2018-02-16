using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenMove : MonoBehaviour {

    private SpriteRenderer sr;
    private Transform tr;
    private Rigidbody2D rb;

    public float maxHorizontalSpeed;

    // Use this for initialization
    void Start ()
    {
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {


        // Update move
        tr.position += new Vector3(Input.GetAxis("Horizontal") * maxHorizontalSpeed * Time.deltaTime, 0, 0);

        if (Input.GetAxis("Horizontal") < 0)
            sr.flipX = true;
        else if (Input.GetAxis("Horizontal") > 0)
            sr.flipX = false;
    }

    internal void jump()
    {
        rb.velocity = new Vector2(0, 5);
    }
}
