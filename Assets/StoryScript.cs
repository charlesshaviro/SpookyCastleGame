using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour {

	public GameObject Story1, Story2;

	public Button NextButton;

	// Use this for initialization
	void Start () {
		NextButton = NextButton.GetComponent<Button> (); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NextClicked(){
		Story1.SetActive (false);
		Story2.SetActive (true);
	}

	public void StartClicked(){
		SceneManager.LoadScene (1);
	}
}
