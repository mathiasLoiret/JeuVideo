using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watchChicken : MonoBehaviour {

	private SpriteRenderer sr;
	public Transform chickenTransform;
	private Transform beeTransform;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		beeTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(beeTransform.position.x > chickenTransform.position.x){
			sr.flipX = false;
		}
		else{
			sr.flipX = true;
		}
	}
}
