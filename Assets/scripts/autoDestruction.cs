using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestruction : MonoBehaviour {

    public float secondBeforDestoy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject.name == "Plume(Clone)")
            Destroy(gameObject, 1f);
	}
}
