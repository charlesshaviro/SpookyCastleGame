﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Questions
// Awkward and buggy when going against movement of moving platform?/when moving down
// Ground moves up hierarchy when on different platform?
// Putting different colliders on same object to prevent sticky platforms?
// Coroutine is messy for Fade - suggestions?
// Monster going of screen????


public class PlayerController : MonoBehaviour {

	[HideInInspector] public bool FacingRight = true;
	[HideInInspector] public bool Jump = false;

	public float MoveForce = 365f;
	public float MaxSpeed = 5f;
	public float JumpForce = 1000f;
	public Transform GroundCheck;

	private bool Grounded = false;
	private Rigidbody2D rb2d;

	public GameObject myInventory;
	private bool faded = false;

	public int livesLeft;
	public bool lostLife;

	public Vector3 originalPosition;


	void Awake(){
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		livesLeft = 3;
		lostLife = false;
	}
	
	// Update is called once per frame
	void Update () {
		Grounded = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if (Input.GetButtonDown ("Jump") && Grounded) {
			Jump = true;
		}
		GameObject[] coinList = GameObject.FindGameObjectsWithTag ("Coin");
		GameObject cage = GameObject.FindGameObjectWithTag ("Cage");
		if (coinList.Length == 0) {
			StartCoroutine (Fade ());
			if (cage == null) {
				StopCoroutine (Fade ());
			}
		}
		if (lostLife == true) {
			LoseALife ();
			lostLife = false;
		}
	}

	void LoseALife(){
		GameObject[] lives = GameObject.FindGameObjectsWithTag ("Life");
		if (livesLeft == 3) {
			lives[2].SetActive (false);
		} else if (livesLeft == 2) {
			lives[1].SetActive (false);
		} else if (livesLeft == 1) {
			lives[0].SetActive (false);
		} else {
			//lose the game
		}
		livesLeft--;
	}



	void FixedUpdate(){
		float H = Input.GetAxis ("Horizontal");
		if (H * rb2d.velocity.x < MaxSpeed)
		{
			rb2d.AddForce (Vector2.right * H * MoveForce);
		}

		if (Mathf.Abs(rb2d.velocity.x) > MaxSpeed)
		{
			rb2d.velocity = new Vector2 ( Mathf.Sign( rb2d.velocity.x) * MaxSpeed, rb2d.velocity.y);
		}
		if ( H>0 && !FacingRight)
		{
			Flip();
		}
		else if( H<0 && FacingRight)
		{
			Flip();
		}
		if(Jump)
		{
			rb2d.AddForce( new Vector2 (0f, JumpForce));
			Jump = false;
		}
	}

	void Flip(){
		FacingRight = !FacingRight;
		Vector3 TheScale = transform.localScale;
		TheScale.x *= -1;
		transform.localScale = TheScale;
	}

	void OnTriggerEnter2D(Collider2D other){
//		if (other.gameObject.CompareTag ("MovingPlatform")) {
//			debug.text = "HERE";
//			transform.parent = other.transform;
//		}
		if (other.gameObject.CompareTag ("Key")) {
			int KeyNumber = other.gameObject.GetComponent<KeyController> ().KeyIndex;
			gameObject.GetComponent<Inventory> ().Keys [KeyNumber] = true;
			Destroy (other.gameObject);
			myInventory.SetActive (true);
		} else if (other.gameObject.CompareTag ("Monster") || other.gameObject.CompareTag("MonsterTrigger")) {
			transform.position = originalPosition;
			lostLife = true;

		}
	}

//	void OnTriggerStay2D(Collider2D other){
//		if (other.gameObject.CompareTag ("Monster")) {
//			transform.position -= new Vector3 (3f, 0, 0);
//
//		}
//	}




	IEnumerator Fade(){
		GameObject cage = GameObject.FindGameObjectWithTag ("Cage");
		while (cage!=null) {
			for (float t = 0f; t < 1.0f; t += Time.deltaTime) {
				if (cage != null) {
					cage.GetComponent<Renderer> ().material.color = Color.Lerp (Color.white, Color.black, t);
				}

				yield return new WaitForSeconds (.01f);

			}
			Destroy (cage.gameObject);
			break;
		}


	}

//	void OnTriggerExit2D(Collider2D other){
//		if (other.gameObject.CompareTag ("MovingPlatform")) {
//			transform.parent = null;
//		}
//	}
}
