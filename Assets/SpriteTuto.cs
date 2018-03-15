using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTuto : MonoBehaviour {
	public Sprite tutoSprite;
	public GameObject spriteRendererParent;
	private SpriteRenderer spriteRenderer;
	private float timeScaleBackUp;
	private bool paused;
	void Start () {
		timeScaleBackUp = Time.timeScale;
		spriteRenderer = spriteRendererParent.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(paused && Input.GetButton("Fire1")){
			spriteRenderer.sprite = null;
			Time.timeScale = timeScaleBackUp;
			paused = false;
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player")
        {
			spriteRenderer.sprite = tutoSprite;
			Time.timeScale = 0;
			paused = true;
		}
    }

}