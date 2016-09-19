using UnityEngine;
using System.Collections;


public class CoinPickup : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other)
	{
		// checks for Coin
		if (other.gameObject.CompareTag ("Coin")) {


			// figures out whether player has picked up a Gold or Silver coin, assigns respective ScoreIncrease
			int ScoreIncease;
			if (other.gameObject.GetComponent<Coin> ().CoinType == 0) {
				ScoreIncease = 1;
			} else {
				ScoreIncease = 5;
			}

			//gameObject.GetComponent<Inventory>().Score += ScoreIncease;

			Debug.Log ("you collected a coin !!!");
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
