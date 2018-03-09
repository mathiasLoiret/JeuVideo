using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableScripte : MonoBehaviour {

    public Transform progress;
    public AudioSource source;
    private Transform tr;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
    

        if (collision.tag == "Player")
        {
            source.Play();
            Destroy(this.gameObject);
            tr.parent.parent.GetComponent<gameManager>().hadCollected(tr.parent.tag, 1);
            progress.GetComponent<lifeScript>().addHp(1f);
        }
            
    }
}
