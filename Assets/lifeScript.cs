using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lifeScript : MonoBehaviour {

    public SpriteRenderer activ;
    public SpriteRenderer unactiv;

    public int max;
    public float actual;

    public float symbloleScale;
    public float adjuster;

    private float max_old = 0;
    private float actual_old;

    // Use this for initialization
    void Start ()
    {
        updateMax();
        updateActual();
    }
	
	// Update is called once per frame
	void Update () {
    }

    internal void addHp(float v)
    {
        this.actual += v;
        updateActual();
    }

    void updateActual()
    {

        if(actual < 0)
            actual = 0;
        else if (actual > max)
            actual = max;

        float delta = (actual_old - actual) * symbloleScale * 2* adjuster;
        actual_old = actual;

        activ.transform.position = new Vector2(activ.transform.position.x - delta, activ.transform.position.y);
        activ.size = new Vector2(symbloleScale * actual, activ.size.y);

        if(this.name == "Progress")
            testVictory();
    }

    private void testVictory()
    {
        if (actual >= max)
        {
           // Debug.Log("victory");
            GetComponent<Transform>().parent.parent.parent.GetComponent<gameManager>().victory();
        }
            
    }

    void updateMax()
    {
        if (max < 1)
            max = 1;

        //DO STUFF
        float delta = (max_old - max) * symbloleScale *2 * adjuster;
        max_old = max;

  //      if (delta != 0)
//            Debug.Log(delta);

        unactiv.transform.position = new Vector2(unactiv.transform.position.x - delta, unactiv.transform.position.y);
        //unactiv.transform.position = new Vector2(unactiv.transform.position.x, unactiv.transform.position.y);
        unactiv.size = new Vector2(symbloleScale * max, unactiv.size.y);

    }

    private void OnServerInitialized()
    {
        
    }
}
