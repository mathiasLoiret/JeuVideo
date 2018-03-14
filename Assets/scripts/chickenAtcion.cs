using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenAtcion : MonoBehaviour {

    public Transform munition;
    public Rigidbody2D projectile;
    public float attaqueSpeed;
    private float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        // SBO: Input.GetButtonDown sera plus pertinent pour un button que GetAxis
        if(timer > attaqueSpeed && Input.GetAxis("Fire1")>0 )
        {
            fire();
            timer = 0;
        }
                
	}

    void fire()
    {
        //Instantiate(munition, transform.position, transform.rotation);
        Rigidbody2D clone;
        Vector3 newPos = transform.position;
        newPos.x += 1;
        clone = Instantiate(projectile, newPos, transform.rotation) as Rigidbody2D;
        clone.velocity = new Vector3(10, 0, 0);  //transform.TransformDirection(Vector3.forward * 10);
        //Destroy(clone, 1f);
    }
}
