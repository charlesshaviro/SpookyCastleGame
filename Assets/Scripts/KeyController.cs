using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {


	public int KeyIndex;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("MovingPlatform")) {
			transform.parent = other.transform;
		} 
	}
}
