using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBottom : MonoBehaviour {

	public GameObject CenterCam;
	public GameObject Player;

    void Start ()
    {
		
    }
    
    void LateUpdate (){

		if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") < 0.1 && Input.GetAxis("Horizontal") > - 0.1
		&& Player.GetComponentInChildren<resetJump>().GetOnPlatform()){
			CenterCam.transform.position +=  new Vector3 (0, -3, 0);
		}

	}
}
