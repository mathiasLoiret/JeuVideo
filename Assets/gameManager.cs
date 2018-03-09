using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{


    public Transform victoryPic;

    private Vector3 respownPosition;

    // Use this for initialization
    void Start()
    {
        victoryPic.GetComponent<Renderer>().enabled = false;
        respownPosition = GetComponent<Transform>().position;

    }

    // Update is called once per frame
    void Update()
    {
    }

    internal void victory()
    {
        victoryPic.GetComponent<Renderer>().enabled = true;
    }

    internal void hadCollected(string name, int v)
    {
        transform.Find("Player&Cam").Find("Main Camera").Find("Progress").GetComponent<lifeScript>().addHp(1f);

    }

    internal void playerHaveBeenHurt(float v)
    {
        if (transform.Find("Player&Cam").Find("Main Camera").Find("Life").GetComponent<lifeScript>().addHp(-1f) < 1)
        {
            Debug.Log("you lose");
            SceneManager.LoadScene("MenuPrincp", LoadSceneMode.Single);
        }
        else
        {
            Transform player_tr = transform.Find("Player&Cam").Find("PlayerContainer").Find("Player").GetComponent<Transform>();
            player_tr.position = respownPosition + new Vector3(0, 2, 0);
            player_tr.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            transform.Find("Player&Cam").Find("PlayerContainer").Find("Player").Find("EnergieBar").GetComponent<lifeBarScript>().addLP(3f);
        }
    }
}
