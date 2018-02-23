using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeScript : MonoBehaviour {

    public Rigidbody2D activ;
    public Rigidbody2D unactiv;

    public int max;
    public int actual;
    public float xSpaceBetwin;
    public float ySpaceBetwin;

    private Rigidbody2D[] activList ;
    private Rigidbody2D[] unactivList;

    // Use this for initialization
    void Start () {
        updateActual(actual);
        max += 1;
        updateMax(max-1);
        updateDisplay();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void updateDisplay()
    {
        for (int i = 0; i < max; i++)
        {
            Rigidbody2D rb = activList[i];
            if (actual > i)
            {
                activList[i].transform.position = new Vector3(
                        activList[i].transform.position.x + xSpaceBetwin * i,
                        activList[i].transform.position.y + ySpaceBetwin * i,
                        0
                        );

                unactivList[i].transform.position = new Vector3(
                        unactivList[i].transform.position.x + xSpaceBetwin * i,
                        unactivList[i].transform.position.y + ySpaceBetwin * i,
                        1
                        );
            }
            else
            {
                activList[i].transform.position = new Vector3(
                        activList[i].transform.position.x + xSpaceBetwin * i,
                        activList[i].transform.position.y + ySpaceBetwin * i,
                        1
                        );

                unactivList[i].transform.position = new Vector3(
                        unactivList[i].transform.position.x + xSpaceBetwin * i,
                        unactivList[i].transform.position.y + ySpaceBetwin * i,
                        0
                        );
            }
                
        }
    }

    void updateActual(int i)
    {
        if(i < 0)
        {
            actual = 0;
        }
        else if (i > max)
        {
            actual = max;
        }
        else
        {
            actual = i;
        }
    }

    void updateMax(int max)
    {
        if (max != this.max)
        {
            this.max = max;
            Rigidbody2D[] newActivList = new Rigidbody2D[max];
            Rigidbody2D[] newUnactivList = new Rigidbody2D[max];
            for (int i = 0; i < max; i++)
            {
                Rigidbody2D clone;
                clone = Instantiate(activ, activ.position, activ.transform.rotation) as Rigidbody2D;
                clone.transform.parent = activ.transform.parent;
                newActivList[i] = clone;
                clone = Instantiate(unactiv, unactiv.position, unactiv.transform.rotation) as Rigidbody2D;
                clone.transform.parent = unactiv.transform.parent;
                newUnactivList[i] = clone;
            }
            activList = newActivList;
            unactivList = newUnactivList;
        }
    }

    private void OnServerInitialized()
    {
        
    }
}
