using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staticDisplay : MonoBehaviour {

    private float realFps = 0;
    public Text fps;
    public Text jumpCounter;
    public Text collectableCounter;
    public Text finalMessage;

    // Use this for initialization
    void Start () {
        try
        {
            finalMessage.text = "";
        }
        catch (Exception e) { }

    }
	
	// Update is called once per frame
	void Update () {
        try
        {
            realFps = 1 / Time.deltaTime;
            double roundedFps = System.Math.Round(realFps);
            fps.text = "FPS : " + roundedFps;

        }
        catch (Exception e) { }
    }

    internal void updateFinal(string finalMessageTxt)
    {
        finalMessage.text = finalMessageTxt;
    }

    internal void updateJumpCounter(int nbJumps, int maxfollowedJump)
    {
        jumpCounter.text = "Jumps : " + nbJumps + " /" +  maxfollowedJump;
    }

    internal void updateCollectableCounter(int collectableCounter, int maxCollectableJumps)
    {
        this.collectableCounter.text = "Plumes : " + collectableCounter + " /" + maxCollectableJumps;
        if (collectableCounter >= maxCollectableJumps)
            finalMessage.text = "YOU WIN !!";
    }
}
