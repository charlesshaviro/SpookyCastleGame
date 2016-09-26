using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public int DoorIndex;
	public int nextLevel;

	public AudioClip DoorSound;


	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Door")) {
			bool hasKey = GetComponent<PlayerController> ().hasKey;
			if (hasKey) {
				StartCoroutine (WaitForLevel ());
				hasKey = false;
			}

		}
	}

	IEnumerator WaitForLevel(){
		AudioSource.PlayClipAtPoint (DoorSound, transform.position);
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (nextLevel);
	}
		

}
