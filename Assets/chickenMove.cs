using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenMove : MonoBehaviour {

    private SpriteRenderer sr;
    private Transform tr;
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    public float maxHorizontalSpeed;
    public float jumpInitialSpeed;

    private int jumpsCounter;

    // Use this for initialization
    void Start ()
    {
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        jumpsCounter = 0;

    }
	
	// Update is called once per frame
	void Update () {


        // Update move
        tr.position += new Vector3(Input.GetAxis("Horizontal") * maxHorizontalSpeed * Time.deltaTime, 0, 0);

        if (Input.GetAxis("Horizontal") < 0)
            sr.flipX = true;
        else if (Input.GetAxis("Horizontal") > 0)
            sr.flipX = false;

        // Update Jump
        if (false)
            jumpsCounter = 0;
    }

    internal void jump()
    {
        jumpsCounter++;
        GetComponent<staticDisplay>().updateJumpCounter(jumpsCounter, 3);
        rb.velocity = new Vector2(0, jumpInitialSpeed);
    }
}
