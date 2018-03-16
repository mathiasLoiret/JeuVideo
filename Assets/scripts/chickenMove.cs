using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenMove : MonoBehaviour {

    private SpriteRenderer sr;
    private Transform tr;
    private Rigidbody2D rb;

    public float maxHorizontalSpeed;
    public float jumpInitialSpeed;

    public int maxConsecutivJumps;
    public int maxCollectableJumps;

    public Transform manaBar;
    public Transform progressBar;

    private int jumpsCounter;
    private int collectableCounter;


    // Use this for initialization
    void Start ()
    {
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        jumpsCounter = 0;
        collectableCounter = 0;

    }
	
	// Update is called once per frame
	void Update () {


        // Update move
        tr.position += new Vector3(Input.GetAxis("Horizontal") * maxHorizontalSpeed * Time.deltaTime, 0, 0);

        if (Input.GetAxis("Horizontal") < 0)
            sr.flipX = true;
        else if (Input.GetAxis("Horizontal") > 0)
            sr.flipX = false;

        // detection de chute / fin de niveau
        if(tr.position.y < -30)
            GetComponent<staticDisplay>().updateFinal("YOU LOSE !!!");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //doCollectThings(collision.collider);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "collectable_1")
            doCollectThings(other);
        else
        {
            // Update Jump
            manaBar.GetComponent<lifeBarScript>().resetLifeBar(3f, 3f);
            jumpsCounter = 0;
            GetComponent<staticDisplay>().updateJumpCounter(jumpsCounter, maxConsecutivJumps);

        }

    }

    private void doCollectThings(Collider2D c)
    { 
        if (c.tag == "collectable_1")
        {
            collectableCounter++;
            GetComponent<staticDisplay>().updateCollectableCounter(collectableCounter, maxCollectableJumps);
            Destroy(c.gameObject);
            progressBar.GetComponent<lifeBarScript>().addLP(10f);
        }
    }

    internal int jump()
    {
        // lifeBarUdate
        manaBar.GetComponent<lifeBarScript>().addLP(-1.0f);

        if (jumpsCounter < maxConsecutivJumps)
        {
            // Update counter;
            jumpsCounter++;
            GetComponent<staticDisplay>().updateJumpCounter(jumpsCounter, maxConsecutivJumps);
            rb.velocity = new Vector2(0, jumpInitialSpeed);
            return jumpsCounter;
        }
        else
        {
            return -1;
        }
        
    }
}
