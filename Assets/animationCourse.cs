using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animationCourse : MonoBehaviour
{

    public Sprite[] wait_sprites;
    public Sprite[] run_sprites;
    public Sprite[] jump_sprites;
    public Sprite[] roulade_sprites;

    public float minFps = 10;
    private float realFps = 0;
    public Text txt;

    private SpriteRenderer sr;
    private Transform tr;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Vector2 init_offset;
    private Vector2 init_size;

    private float deltaTime = 0.0f;
    private string defaultAction = "wait";
    private Sprite[] current_sprite;
    private string currentAction = "wait";
    private string nextAction = "wait";
    private string[] notPrioritareAction = { "wait", "run" };

    private float y;

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
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        current_sprite = wait_sprites; // cause default
        curentIndex = 0;
        init_offset = bc.offset;
        init_size = bc.size;
    }

    // Update is called once per frame
    void Update()
    {
        //if (sprites.Length == 0) return;
        realFps = 1 / Time.deltaTime;
        txt.text = "FPS : " + System.Math.Round(realFps);

        //bc.offset = init_offset;
        //bc.size = init_size;

        if (Input.GetKey(KeyCode.Space))
        {
            if(currentAction != "space" || current_sprite.Length-1 == curentIndex)
            {
                nextAction = "space";
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && currentAction != "run")
        {
            if (currentAction != "run" || current_sprite.Length - 1 == curentIndex)
            {
                nextAction = "run";
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (currentAction != "down" || current_sprite.Length - 1 == curentIndex)
            {
                nextAction = "down";
            }
            //bc.offset = new Vector2(0.36f, -1.31f);
            //bc.size = new Vector2(4.41f, 3.33f);

        }

        /*/ Auteur du saut
        y = 0.1f;
        if(currentAction == "space")
            y = 2;
        tr.position = new Vector3(tr.position.x, y, 0);
        */


        // Gestion des fps
        deltaTime += Time.deltaTime;
        if (deltaTime > 1 / minFps)
        {

            // si on est sur l'action de base on attend pas pour changer d'action
            if (IsInArray(notPrioritareAction, currentAction) && nextAction != defaultAction)
            {
                curentIndex = -1;
            }

            // si une serie d'image est fini, on passe à la suivante et on met a jour la serie d'image à afficher.
            curentIndex = (curentIndex + 1) % current_sprite.Length;
            if (curentIndex == 0)
            {
                currentAction = nextAction;
                nextAction = defaultAction;

                if (currentAction == "space")
                {
                    current_sprite = jump_sprites;
                    rb.velocity = new Vector2(0, 5);
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
