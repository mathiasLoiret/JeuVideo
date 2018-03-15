using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{


    public Transform victoryPic;
    public AudioClip winclip;

    private Vector3 respownPosition;

    private float deltaTime = 0.0f;
    private float minTimeBetwinDamage = 1f;

    private int progressMax;

    // Use this for initialization
    void Start()
    {
        victoryPic.GetComponent<Renderer>().enabled = false;
        respownPosition = GetComponent<Transform>().position;
        progressMax = transform.Find("Player&Cam").Find("Main Camera").Find("Progress").GetComponent<lifeScript>().getMax();
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
    }

    internal void victory()
    {
        victoryPic.GetComponent<Renderer>().enabled = true;
        GetComponent<AudioSource>().clip = winclip;
        GetComponent<AudioSource>().Play();
    }

    internal void hadCollected(string name, int v)
    {
        if (transform.Find("Player&Cam").Find("Main Camera").Find("Progress").GetComponent<lifeScript>().addHp(1f) >= progressMax)
        {
            victory();
        }

    }

    internal void playerHaveBeenHurt(float v)
    {
        if (deltaTime > minTimeBetwinDamage)
        {
            if (transform.Find("Player&Cam").Find("Main Camera").Find("Life").GetComponent<lifeScript>().addHp(-1f) < 1)
            {
                Debug.Log("you lose");
                SceneManager.LoadScene("MenuPrincp", LoadSceneMode.Single);
            }
            else
            {
                transform.Find("Player&Cam").Find("CenterCam").GetComponent<CenterCam>().freez(0.5f);
                Transform player_tr = transform.Find("Player&Cam").Find("PlayerContainer").Find("Player").GetComponent<Transform>();
                player_tr.position = respownPosition + new Vector3(0, 2, 0);
                player_tr.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                transform.Find("Player&Cam").Find("PlayerContainer").Find("Player").Find("EnergieBar").GetComponent<lifeBarScript>().addLP(3f);
            }
            deltaTime = 0;
        }
        
    }
}
