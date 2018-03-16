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

    public Transform life;
    public Transform progress;
    public Transform player;
    public Transform bee;
    public Transform centerCam;

    // Use this for initialization
    void Start()
    {
        victoryPic.GetComponent<Renderer>().enabled = false;
        respownPosition = GetComponent<Transform>().position + new Vector3(-3, 2, 0);
        progressMax = progress.GetComponent<lifeScript>().getMax();
        player_tr = player.GetComponent<Transform>();
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
        if (progress.GetComponent<lifeScript>().addHp(1f) >= progressMax)
        {
            victory();
        }

    }

    internal void playerHaveBeenHurt(float v)
    {
        hurt.Play();
        if (deltaTime > minTimeBetwinDamage)
        {
            if (life.GetComponent<lifeScript>().addHp(-1f) < 1)
            {
                Debug.Log("You lose");
                SceneManager.LoadScene("MenuPrincp", LoadSceneMode.Single);
            }
            else
            {
                centerCam.GetComponent<CenterCam>().freez(0.5f);
                player.GetComponentInChildren<lifeBarScript>().addLP(3f);
                bee.position = respownPosition + new Vector3(2, 2, 0);
            }
            deltaTime = 0;
        }
        
    }
}
