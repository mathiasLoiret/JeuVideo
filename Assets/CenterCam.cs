using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCam : MonoBehaviour {

	public float vitesse;
	public GameObject  player;
	
	// Update is called once per frame
	void Update () {

		this.transform.position = player.transform.position + new Vector3(Input.GetAxis("Horizontal")*vitesse, 0, 0);

	}
}
