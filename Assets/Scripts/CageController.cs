using UnityEngine;
using System.Collections;

public class CageController : MonoBehaviour {

	public AudioClip CageSound;

	void Start () {
	
	}

	void Update () {
	}


	public void StartFade(){
		StartCoroutine (Fade ());
	}
	// Fades out cage game object
	IEnumerator Fade(){

		AudioSource.PlayClipAtPoint (CageSound, transform.position);
		for (float t = 0f; t < 1.0f; t += Time.deltaTime) {
			if (this != null) {
				this.GetComponent<Renderer> ().material.color = Color.Lerp (Color.white, Color.black, t);
			}
			yield return new WaitForSeconds (.01f);
		}

		Destroy (this.gameObject);

	}
}
