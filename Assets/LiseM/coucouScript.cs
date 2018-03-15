using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct Animation {
	public string name;
	public Sprite[] sprites;
}
public class coucouScript : MonoBehaviour {

	public Animation[] anims;
	public int imagesParSecondes = 24;

	private SpriteRenderer spriteRenderer;

	private int currentSpriteIdx = 0;
	private int currentAnim = 0;
	private float accumulateur = 0;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {

		// durée souhaitée d'une frame
		float frameDuration = GetFrameDurationInSec ();

		// durée accumulée depuis le dernier changement de frame
		accumulateur += Time.deltaTime;

		// vide l'accumulateur et fait avancer les frames        
		if (accumulateur > frameDuration) {
			NextFrame ();
			accumulateur -= frameDuration;
		}

	}

	float GetFrameDurationInSec () {
		return 1f / imagesParSecondes;
	}

	public void NextFrame () {
		currentSpriteIdx = (currentSpriteIdx + 1) % anims[currentAnim].sprites.Length;
		spriteRenderer.sprite = anims[currentAnim].sprites[currentSpriteIdx];
	}
}