using UnityEngine;
using System.Collections;

public class LeverScript : MonoBehaviour {

	[HideInInspector] public bool FacingOff = true;

	public AudioClip LeverSound, MonsterSound;

	public GameObject Key;

	void Start () {
	
	}

	void Update () {
		
	
	}

	/** Flips to indicate the player has pulled the lever **/
	void Flip(){
		FacingOff = !FacingOff;
		Vector3 TheScale = transform.localScale;
		TheScale.x *= -1;
		transform.localScale = TheScale;
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.CompareTag ("Player") && FacingOff) {
			Flip ();
			Key.SetActive (true);
			GameObject Monster = GameObject.FindGameObjectWithTag ("MonsterTrigger");

			if (Monster != null) {
				Monster.GetComponent<MonsterController> ().Grow ();
				AudioSource.PlayClipAtPoint (MonsterSound, transform.position);
			} else {
				AudioSource.PlayClipAtPoint (LeverSound, transform.position);
			}
		}
	}
}
