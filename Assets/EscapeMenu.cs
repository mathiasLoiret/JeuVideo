using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour {


	public Button restart;
	public Button menuPincip;
	public bool escapeMenuOpen; 
	public Image panel;
	private Scene scene; 
	
	
	// Update is called once per frame
	void Update () {
		scene = SceneManager.GetActiveScene();
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(escapeMenuOpen == false){
				escapeMenuOpen = true;
				restart.gameObject.SetActive(true);
				menuPincip.gameObject.SetActive(true);
				panel.gameObject.SetActive(true);
			}else{
				escapeMenuOpen = false;
				restart.gameObject.SetActive(false);
				menuPincip.gameObject.SetActive(false);		
				panel.gameObject.SetActive(false);	
			}
		}else{

		}

	}

	public void GoToMenuPrincip(){
		SceneManager.LoadScene("MenuPrincp");
	} 	

	public void RestartLevel(){
		SceneManager.LoadScene(scene.name);
	}
}
