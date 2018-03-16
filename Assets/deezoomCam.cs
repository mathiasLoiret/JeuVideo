using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deezoomCam : MonoBehaviour {

	private bool isDeZoomed; 

	// Use this for initialization
	void Start () {
		isDeZoomed = false;
	}
     
     void Update () {

		if(Input.GetButton("U")){
			Debug.Log(isDeZoomed);
			Debug.Log(Camera.main.orthographicSize);
			isDeZoomed = !isDeZoomed;
		}

		if (isDeZoomed == true){
			Camera.main.orthographicSize = 6f;
		}
		if (isDeZoomed == false){
		 	Camera.main.orthographicSize = 5f;
		 }
     }
}
