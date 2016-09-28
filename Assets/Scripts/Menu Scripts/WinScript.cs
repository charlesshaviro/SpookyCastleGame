using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {


	public Button PlayAgainButton;
	public Text FinalScoreText;
	public GameObject player;

	// Use this for initialization
	void Start () {
		PlayAgainButton = PlayAgainButton.GetComponent<Button> ();
		player.GetComponent<PlayerController> ().LoadScore();
		int score = player.GetComponent<PlayerController> ().score;
		if (score != null) {
			FinalScoreText.text = "You scored " + score + " out of 144!";
		} else {
			FinalScoreText.text = "";
		}
		Debug.Log (score);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Loads start screen
	public void PlayAgain(){
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene (0);
	}
}
