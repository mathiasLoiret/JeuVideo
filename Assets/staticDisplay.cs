using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staticDisplay : MonoBehaviour {

    private float realFps = 0;
    public Text txt;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Update fps
        realFps = 1 / Time.deltaTime;
        txt.text = "FPS : " + System.Math.Round(realFps);
    }
}
