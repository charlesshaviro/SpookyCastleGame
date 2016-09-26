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

		QuitMenu = QuitMenu.GetComponent<Canvas> ();
		StartButton = StartButton.GetComponent<Button> (); 
		ExitButton = ExitButton.GetComponent<Button> ();

		QuitMenu.enabled = false;

	}

	public void ExitClick(){

		QuitMenu.enabled = true;
		StartButton.enabled = false;
		ExitButton.enabled = false;
	}

	public void NoClick(){

		QuitMenu.enabled = false;
		StartButton.enabled = true;
		ExitButton.enabled = true;	
	}


	public void StartLevel(){

		SceneManager.LoadScene (1);

	}

	public void QuitGame(){

		Application.Quit ();
	}





}
