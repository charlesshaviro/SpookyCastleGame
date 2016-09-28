using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InventoryScript : MonoBehaviour {

	public GameObject Life1, Life2, Life3;
	public AudioClip DyingSound;



	void Start () {

	}

	// Handles game effects when player loses a life
	public void LoseOneLife(int livesLeft){
		AudioSource.PlayClipAtPoint (DyingSound, transform.position);
		if (livesLeft == 3) {
			Life3.SetActive (false);
		} else if (livesLeft == 2) {
			Life2.SetActive (false);
		} else if (livesLeft == 1) {
			Life1.SetActive (false);
			SceneManager.LoadScene (10);
		}

	}

}
