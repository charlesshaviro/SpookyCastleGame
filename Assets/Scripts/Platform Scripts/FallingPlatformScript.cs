using UnityEngine;
using System.Collections;

public class FallingPlatformScript : MonoBehaviour {

	public float fallTime;

	void Start () {
	
	}

	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		// Forces platform to fall after colliding with Player
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine (Fall ());
		}
	}

	// Forces platform to fall offscreen after specified amount of time
	IEnumerator Fall(){
		yield return new WaitForSeconds (fallTime);
		if (!gameObject.GetComponent<Rigidbody2D> ()) {
			Rigidbody2D rb2d = gameObject.AddComponent<Rigidbody2D> ();
		}
		yield return new WaitForSeconds(4f);
		Destroy (gameObject);
	}
}
