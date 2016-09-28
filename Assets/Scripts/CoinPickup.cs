using UnityEngine;
using System.Collections;


public class CoinPickup : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other)
	{
		// checks for Coin
		if (other.gameObject.CompareTag ("Coin")) {
			int coinValue = other.GetComponent<Coin> ().GetCoinValue ();
			GetComponent<PlayerController> ().score += coinValue;
			// gets rid of Coin
			Destroy (other.gameObject);

		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
