using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTuto : MonoBehaviour {
	public Sprite[] tutoSprite;
	public GameObject spriteRendererParent;
	private SpriteRenderer spriteRenderer;
	private float timeScaleBackUp;
	private bool paused;
	private bool wait;
	private int waitingFrame =5;
	private int index =0;
	void Start () {
		timeScaleBackUp = Time.timeScale;
		spriteRenderer = spriteRendererParent.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(wait){
			waitingFrame--;
			if(waitingFrame ==0){
				waitingFrame = 10;
				wait = false;
			}
		}else{
			if(paused && Input.GetButton("Fire1")){
			if(index +1 <= tutoSprite.Length -1){
				wait = true;
				index++;
				spriteRenderer.sprite = tutoSprite[index];
			}else{
				wait = true;
				spriteRenderer.sprite = null;
				Time.timeScale = timeScaleBackUp;
				paused = false;
				Destroy(this.gameObject);
			}
			
		}
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player")
        {
			spriteRenderer.sprite = tutoSprite[index];
			Time.timeScale = 0;
			paused = true;
		}
    }

}