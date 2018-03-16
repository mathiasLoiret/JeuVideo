using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	public void ChangeScene (string sceneName){
        Time.timeScale = 1;
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
		Debug.Log("charge scene" + sceneName);
	}

}
