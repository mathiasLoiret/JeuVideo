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

    private float deltaTime = 1.0f;
    private float minTimeBetwinDamage = 1f;

    private Transform player_tr;

    private int progressMax;
    public AudioSource hurt;

    // Use this for initialization
    void Start()
    {
        victoryPic.GetComponent<Renderer>().enabled = false;
        respownPosition = GetComponent<Transform>().position + new Vector3(-3, 2, 0);
        progressMax = transform.Find("Player&Cam").Find("Main Camera").Find("Progress").GetComponent<lifeScript>().getMax();
        player_tr = transform.Find("Player&Cam").Find("PlayerContainer").Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime < minTimeBetwinDamage)
        {
            player_tr.position = respownPosition;
            player_tr.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }

    internal void victory()
    {
        victoryPic.GetComponent<Renderer>().enabled = true;
        GetComponent<AudioSource>().clip = winclip;
        GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
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
        hurt.Play();
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
                transform.Find("Player&Cam").Find("PlayerContainer").Find("Player").Find("EnergieBar").GetComponent<lifeBarScript>().addLP(3f);
            }
            deltaTime = 0;
        }
        
    }
}
