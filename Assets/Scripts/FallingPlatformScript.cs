using UnityEngine;
using System.Collections;

public class FallingPlatformScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine (Fall ());
		}
	}

	IEnumerator Fall(){
		yield return new WaitForSeconds (.5f);
		if (!gameObject.GetComponent<Rigidbody2D> ()) {
			Rigidbody2D rb2d = gameObject.AddComponent<Rigidbody2D> ();
		}
		yield return new WaitForSeconds(4f);
		Destroy (gameObject);
	}
}
