using UnityEngine;
using System.Collections;

public class CageController : MonoBehaviour {

	public AudioClip CageSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		GameObject[] coinList = GameObject.FindGameObjectsWithTag ("Coin");
		Debug.Log (coinList.Length);
		if (coinList.Length == 0) {
			StartCoroutine (Fade ());

		}
	}

	IEnumerator Fade(){
		for (float t = 0f; t < 1.0f; t += Time.deltaTime) {
			if (this != null) {
				this.GetComponent<Renderer> ().material.color = Color.Lerp (Color.white, Color.black, t);
			}
			yield return new WaitForSeconds (.01f);
		}

		Destroy (this.gameObject);

		AudioSource.PlayClipAtPoint (CageSound, transform.position);
	}


//		while (cage!=null) {
//			for (float t = 0f; t < 1.0f; t += Time.deltaTime) {
//				if (cage != null) {
//					cage.GetComponent<Renderer> ().material.color = Color.Lerp (Color.white, Color.black, t);
//				}
//
//				yield return new WaitForSeconds (.01f);
//
//			}
//			Destroy (cage.gameObject);
//			break;
//		}
//
//	}
}
