using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staticDisplay : MonoBehaviour {

    private float realFps = 0;
    public Text fps;
    public Text jumpCounter;
    public Text finalMessage;

    // Use this for initialization
    void Start () {
        finalMessage.text = "";

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

    internal void updateFinal(string finalMessageTxt)
    {
        finalMessage.text = finalMessageTxt;
    }
}
