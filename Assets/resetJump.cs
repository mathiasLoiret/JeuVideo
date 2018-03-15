using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetJump : MonoBehaviour {

    private bool OnPlatform;

	// Use this for initialization
	void Start () {
		OnPlatform = false;
	}
	
	// Update is called once per frame
	void Update () {
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "resetJumpPlatform")
        {
            // Update Jump
            this.transform.parent.GetComponent<movePlayer>().resetJump();
            OnPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        OnPlatform = false;
    }

    internal bool GetOnPlatform()
    {
        return OnPlatform;
    }
}
