using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Canvas QuitMenu;
	public Button StartButton;
	public Button ExitButton;

	// Use this for initialization
	void Start () {

		PlayerPrefs.DeleteAll ();
		QuitMenu = QuitMenu.GetComponent<Canvas> ();
		StartButton = StartButton.GetComponent<Button> (); 
		ExitButton = ExitButton.GetComponent<Button> ();

		QuitMenu.enabled = false;

	}

	// Enables quit confirmation screen
	public void ExitClick(){

		QuitMenu.enabled = true;
		StartButton.enabled = false;
		ExitButton.enabled = false;
	}

	// Re-enables start page 
	public void NoClick(){

		QuitMenu.enabled = false;
		StartButton.enabled = true;
		ExitButton.enabled = true;	
	}


	// Loads backstory scene to start the game
	public void StartLevel(){

		SceneManager.LoadScene (7);

	}

	// Quits the game
	public void QuitGame(){

		Application.Quit ();
	}





}
