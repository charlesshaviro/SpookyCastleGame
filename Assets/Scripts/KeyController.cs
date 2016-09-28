using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	public AudioClip KeySound;


	void Start () {
	
	}

	void Update () {
	
	}

	// Plays sound and disappears/is picked up by player
	public void PickUp(){
		AudioSource.PlayClipAtPoint (KeySound, transform.position);
		Destroy (this.gameObject);
	}

}
