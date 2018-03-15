using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renard : MonoBehaviour {

    public Sprite[] renardAnimation;

    private SpriteRenderer sr;
    private int i;

    private float timer;
    private float fps;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        i = 0;
        fps = 2;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            i = (i + 1) % renardAnimation.Length;
            sr.sprite = renardAnimation[i];
            timer += 1 / fps;
        }
        
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
