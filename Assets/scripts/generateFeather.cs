using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateFeather : MonoBehaviour {

	public GameObject go;
	public List<Vector2> feathersPos;
	public Transform progress;
	public AudioSource collectSound;
	public GameObject pcc;
	public GameObject bee;

	// Use this for initialization
	void Start () {
		poolManager pool = new poolManager(go, feathersPos.Count);
		for(int i = 0; i<feathersPos.Count; i++)
		{
			GameObject feather = pool.Get();
			feather.transform.position = feathersPos[i];
			feather.GetComponent<collectableScripte>().progress = progress;
			feather.GetComponent<collectableScripte>().source = collectSound;
			feather.GetComponent<collectableScripte>().pcc = pcc;
			feather.GetComponent<collectableScripte>().tag = this.tag;
			feather.GetComponent<collectableScripte>().pool = pool;
			feather.GetComponent<collectableScripte>().bee = bee;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
