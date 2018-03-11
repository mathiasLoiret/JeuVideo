using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("renard-OnTriggerEnter2D-" + collision.transform.name);
        if (collision.transform.name == "danger")
        {
            Destroy(this.gameObject);
        }
    }
}
