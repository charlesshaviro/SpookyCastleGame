using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour {

	public Text text;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Key")) {
			text.text = "HERE!!!";
			int KeyNumber = other.gameObject.GetComponent<KeyController> ().KeyIndex;
			gameObject.GetComponent<Inventory>().Keys[KeyNumber] = true;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
