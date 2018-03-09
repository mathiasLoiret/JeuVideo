using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    private SpriteRenderer sr;
    private Transform tr;
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    public float maxHorizontalSpeed;
    public float jumpInitialSpeed;

    public int maxConsecutivJumps;
    public int maxCollectableJumps;

    public Transform manaBar;

    private int jumpsCounter;

    private int collectableCounter;


    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        jumpsCounter = 0;
        collectableCounter = 0;

    }

    // Update is called once per frame
    void Update()
    {


        // Update move
        tr.position += new Vector3(Input.GetAxis("Horizontal") * maxHorizontalSpeed * Time.deltaTime, 0, 0);

        if (Input.GetAxis("Horizontal") < 0)
            sr.flipX = true;
        else if (Input.GetAxis("Horizontal") > 0)
            sr.flipX = false;

        // detection de chute / fin de niveau
        //if (tr.position.y < -30)
        //    GetComponent<staticDisplay>().updateFinal("YOU LOSE !!!");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "danger")
        {
            tr.parent.parent.GetComponentInParent<gameManager>().playerHaveBeenHurt(-1f);
        }
        else if (collision.transform.tag == "enemy")
        {
            Debug.Log("HO NO AN ENEMY !!!");
            //tr.parent.parent.GetComponentInParent<gameManager>().playerHaveBeenHurt(-1f);
        }
    }

    internal void resetJump()
    {
        manaBar.GetComponent<lifeBarScript>().resetLifeBar(3f, 3f);
        jumpsCounter = 0;
    }

    internal int jump()
    {
        // lifeBarUdate
        manaBar.GetComponent<lifeBarScript>().addLP(-1.0f);

        if (jumpsCounter < maxConsecutivJumps)
        {
            if (jumpsCounter == 0)
            {
                tr.parent.Find("envol_1").GetComponent<windPower>().go();
            }

            // Update counter;
            jumpsCounter++;
            rb.velocity = new Vector2(0, jumpInitialSpeed);

            return jumpsCounter;
        }
        else
        {
            return -1;
        }

    }
}
