using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageParticuleSystem : MonoBehaviour {

	public ParticleSystem ps;
	public ParticleSystem.EmissionModule emission;

	public float acc=0;

	// Use this for initialization
	void Start () {
		emission = ps.emission;
        emission.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		acc += Time.deltaTime;
		if(acc > 0.4f){
			emission.enabled = false;
		}
		if(Input.GetKey("space")){
			emission.enabled = true;
			acc = 0;
		}
	}
}
