using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolManager {
		private List<GameObject> pool = new List<GameObject>();

		public poolManager(GameObject go, int initObjectNumber)
		{
			for(int i = 0; i<initObjectNumber; i++){
				pool.Add(MonoBehaviour.Instantiate(go, Vector3.zero, Quaternion.identity));
			}
		}

		public GameObject Get()
		{
			GameObject go = pool[0];
			pool.Remove(go);
			go.SetActive(true);
			return go;
		}

		public void GiveBack(GameObject go)
		{
			go.SetActive(false);
			pool.Add(go);
		}
}
