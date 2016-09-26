using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	public GameObject Life1, Life2, Life3;

	[HideInInspector] public int livesLeft;
	[HideInInspector] public bool lostLife;

	public Vector3 originalPosition;
	[HideInInspector] public bool hasKey;

	public AudioClip DyingSound, KeySound;

	void Awake(){
		rb2d = GetComponent<Rigidbody2D> ();
	}
		
	void Start () {
		originalPosition = transform.position;
		livesLeft = 3;
		lostLife = false;
	}

	void Update () {

		// Platform and movement mechanics
		RaycastHit2D hit = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		Grounded = (hit.collider != null);

		if (Input.GetButtonDown ("Jump") && Grounded) {
			Jump = true;
		}

		if (Grounded) {
			CheckGround (hit.collider);
		} else {
			transform.parent = null;
		}

		if (lostLife == true) {
			LoseALife ();
			lostLife = false;
		}

	}

	/* Checks ground and player interaction */
	void CheckGround(Collider2D collider){

		// If jumping off a platform, reset parent to null
		if (collider == null || Jump) {
			transform.parent = null;
		} else if (collider.CompareTag ("StaticPlatform")) {
			transform.parent = null; 
		} else if (collider.CompareTag ("MoveHorizontal")) {
			if (Input.GetAxis ("Horizontal") == 0) {
				transform.parent = collider.transform;
			} else {
				transform.parent = null;
			}
		} else if (collider.CompareTag ("MoveVertical")) {
			transform.parent = collider.gameObject.transform;
		} else if (collider.CompareTag ("Offscreen")) {
			lostLife = true;
		}
	}


	/* Tracks number of lives, updates UI */
	void LoseALife(){
		if (livesLeft == 3) {
			Life3.SetActive (false);
		} else if (livesLeft == 2) {
			Life2.SetActive (false);
		} else if (livesLeft == 1) {
			Life1.SetActive (false);
		} else {
			
		}

		AudioSource.PlayClipAtPoint (DyingSound, transform.position);
		livesLeft--;
		transform.position = originalPosition;
	}


	/* Player movement mechanics */
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

	/* Flips player to face direction of movement */
	void Flip(){
		FacingRight = !FacingRight;
		Vector3 TheScale = transform.localScale;
		TheScale.x *= -1;
		transform.localScale = TheScale;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Key")) {
			hasKey = true;
			AudioSource.PlayClipAtPoint (KeySound, transform.position);
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("Monster") || other.gameObject.CompareTag("MonsterTrigger")) {
			lostLife = true;
		}
	}
}

