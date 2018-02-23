using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeScript : MonoBehaviour {

    public SpriteRenderer activ;
    public SpriteRenderer unactiv;

    public int max;
    public int actual;

    // Use this for initialization
    void Start () {
        updateActual(actual);
        updateMax(max);
    }
	
	// Update is called once per frame
	void Update () {
        updateMax(max);
	}

    void updateDisplay()
    {
        // DO STUFF
    }

    void updateActual(int i)
    {
        if(i < 0)
            actual = 0;
        else if (i > max)
            actual = max;
        else
            actual = i;

        activ.size = new Vector2(0.13f * actual, unactiv.size.y);
    }

    void updateMax(int max)
    {
        if (max < 1)
            max = 1;

        this.max = max;

        //DO STUFF
        unactiv.size = new Vector2(0.13f * max, unactiv.size.y);


        updateDisplay();
    }

    private void OnServerInitialized()
    {
        
    }
}
