using UnityEngine;
using System.Collections;

public class LeverScript : MonoBehaviour {

	[HideInInspector] public bool FacingOff = true;

	public GameObject key;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Flip(){
		FacingOff = !FacingOff;
		Vector3 TheScale = transform.localScale;
		TheScale.x *= -1;
		transform.localScale = TheScale;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player") && FacingOff) {
			Flip ();
			key.SetActive (true);
			GameObject monster = GameObject.FindGameObjectWithTag ("MonsterTrigger");
			if (monster != null) {
				//make him bigger
			}
		}
	}
}
