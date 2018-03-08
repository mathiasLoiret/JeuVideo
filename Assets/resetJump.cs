using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetJump : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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

        }

    }
}
