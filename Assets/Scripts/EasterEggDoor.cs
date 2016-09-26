using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EasterEggDoor : MonoBehaviour {

	public AudioClip DoorSound;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
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
		SceneManager.LoadScene (9);
	}

}
