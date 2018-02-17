using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staticDisplay : MonoBehaviour {

    private float realFps = 0;
    public Text fps;
    public Text jumpCounter;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        realFps = 1 / Time.deltaTime;
        fps.text = "FPS : " + Math.Round(realFps);
    }

    internal void updateJumpCounter(int nbJumps, int maxfollowedJump)
    {
        jumpCounter.text = "Jumps : " + nbJumps + " /" +  maxfollowedJump;
    }
}
