using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour {

	public GameObject Story1, Story2;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Loads first level of game
	public void StartClicked(){
		SceneManager.LoadScene (1);
	}
}
