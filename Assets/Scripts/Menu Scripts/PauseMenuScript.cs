using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {

	public GameObject PauseMenu;

	void Start () {
		PauseMenu.SetActive (false);
	}
	
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)){

			if (Time.timeScale == 0) {
				Resume ();

			} else {
				Pause ();
			
			}
		
		}
	}


	public void QuitGame(){

		Application.Quit ();
	}

	public void MainMenu(){

		SceneManager.LoadScene (0);
	}

	public void Pause(){

		Time.timeScale = 0;
		PauseMenu.SetActive (true);
	}

	public void Resume(){

		Time.timeScale = 1;
		PauseMenu.SetActive (false);

	}



}
