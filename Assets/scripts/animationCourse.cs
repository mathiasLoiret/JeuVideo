﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationCourse : MonoBehaviour
{

    public Sprite[] wait_sprites;
    public Sprite[] run_sprites;
    public Sprite[] jump_sprites;
    public Sprite[] roulade_sprites;

    public float minFps = 10;

    private SpriteRenderer sr;

    private float deltaTime = 0.0f;
    private string defaultAction = "wait";
    private Sprite[] current_sprite;
    private string currentAction = "wait";
    private string nextAction = "wait";
    private string[] notPrioritareAction = { "wait", "run" };

    private int curentIndex;

    // 
    bool IsInArray(string[] array, string str)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == str)
            {
                return true;
            }
        }
        return false;
    }

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        current_sprite = wait_sprites; // cause default
        curentIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //if (sprites.Length == 0) return;

        // Dection d'appui sur touche
        if (Input.GetKey(KeyCode.Space))
        {
            if(currentAction != "space" || current_sprite.Length-1 == curentIndex)
                nextAction = "space";
        }
        else if (Input.GetAxis("Horizontal")>0 && currentAction != "run")
        {
            if (currentAction != "run" || current_sprite.Length - 1 == curentIndex)
                nextAction = "run";
        }
        else if (Input.GetAxis("Horizontal") <0 && currentAction != "run")
        {
            if (currentAction != "run" || current_sprite.Length - 1 == curentIndex)
                nextAction = "run";
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            if (currentAction != "down" || current_sprite.Length - 1 == curentIndex)
                nextAction = "down";

        }


        // delayed refresh
        deltaTime += Time.deltaTime;
        if (deltaTime > 1 / minFps)
        {

            // si on est sur un action interompable on attend pas pour changer d'action
            if (IsInArray(notPrioritareAction, currentAction) && nextAction != defaultAction)
                curentIndex = -1;


            // si une serie d'image est fini, on passe à la suivante et on met a jour la serie d'image à afficher.
            curentIndex = (curentIndex + 1) % current_sprite.Length;
            if (curentIndex == 0)
            {
                currentAction = nextAction;
                nextAction = defaultAction;

                if (currentAction == "space")
                {
                    current_sprite = jump_sprites;
                    if (GetComponent<chickenMove>().jump() < 0)
                    {
                        currentAction = "down";
                        current_sprite = roulade_sprites;
                    } 
                }
                else if (currentAction == "run")
                {
                    current_sprite = run_sprites;
                }
                else if (currentAction == "wait")
                {
                    current_sprite = wait_sprites;
                }
                else if (currentAction == "down")
                {
                    current_sprite = roulade_sprites;
                }
            }

            sr.sprite = current_sprite[curentIndex];
            deltaTime -= 1 / minFps;
        }

    }
}
