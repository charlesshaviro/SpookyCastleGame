using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	/** Global variables **/
	[HideInInspector] public bool FacingRight = true;
	[HideInInspector] public bool Jump = false;

	public float MoveForce = 365f;
	public float MaxSpeed = 5f;
	public float JumpForce = 1000f;
	public Transform GroundCheck;

	private bool Grounded = false;
	private Rigidbody2D rb2d;

	// Handle when player loses a life
	public GameObject Inventory;
	[HideInInspector] public int livesLeft;
	[HideInInspector] public bool lostLife;

	// Saves original position of player
	public Vector3 originalPosition;

	// True if player has collected the key, false otherwise
	[HideInInspector] public bool hasKey;

	// Keeps track of score
	[HideInInspector] public int score;

	public Text ScoreText;

	void Awake(){
		rb2d = GetComponent<Rigidbody2D> ();
		score = 0;
	}
		
	void Start () {
		originalPosition = transform.position;
		livesLeft = 3;
		lostLife = false;
		LoadScore ();
	}

	void Update () {
		// Platform and movement mechanics
		RaycastHit2D hit = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		Grounded = (hit.collider != null);
		if (Input.GetButtonDown ("Jump") && Grounded) {
			Jump = true;
		}

		// Checks type of platform/collider 
		if (Grounded) {
			CheckGround (hit.collider);
		} else {
			transform.parent = null;
		}

		// Handles losing a life
		if (lostLife == true) {
			LoseOneLife ();
			lostLife = false;
		}
		ScoreText.text = "Score: " + score;
		SaveScore ();

	}

	/** Saves score to local preferences **/
	public void SaveScore(){
		PlayerPrefs.SetInt ("Score", score);
	}

	/** Loads score from local preferences **/
	public void LoadScore(){
		score = PlayerPrefs.GetInt ("Score");
		if (score == null) {
			score = 0;
		}
	}

	/** Checks collider and player interaction **/
	void CheckGround(Collider2D collider){
		// Detaches player from collider
		if (collider == null || Jump || collider.CompareTag("StaticPlatform")) {
			transform.parent = null;
		} else if (collider.CompareTag ("MoveHorizontal")) {
			// Attaches player to collider if idle
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
		
	/** Decrements # of lives left, and adjusts UI for Inventory **/
	void LoseOneLife(){
		Inventory.GetComponent<InventoryScript> ().LoseOneLife (livesLeft);
		transform.position = originalPosition;
		livesLeft--;
	}

	/** Handles player movement mechanics **/
	void FixedUpdate(){
		float H = Input.GetAxis ("Horizontal");

		//Prevents animation from affecting player movement
		if (H == 0) {
			gameObject.GetComponent<Animator> ().enabled = false;
		}
		if (H * rb2d.velocity.x < MaxSpeed){	
			rb2d.AddForce (Vector2.right * H * MoveForce);
		}
		if (Mathf.Abs(rb2d.velocity.x) > MaxSpeed){
			rb2d.velocity = new Vector2 ( Mathf.Sign( rb2d.velocity.x) * MaxSpeed, rb2d.velocity.y);
		}
		if ( H>0 && !FacingRight){	Flip();
		}
		else if( H<0 && FacingRight){
			Flip();
		}
		if(Jump){
			rb2d.AddForce( new Vector2 (0f, JumpForce));
			Jump = false;
		}
	}

	/** Flips player to face direction of movement **/
	void Flip(){
		FacingRight = !FacingRight;
		Vector3 TheScale = transform.localScale;
		TheScale.x *= -1;
		transform.localScale = TheScale;
	}

	/** Detects and handles triggers **/
	void OnTriggerEnter2D(Collider2D other){
		// Found key - enables player to open the door 
		if (other.gameObject.CompareTag ("Key")) {
			hasKey = true;
			other.GetComponent<KeyController> ().PickUp ();
		} 
		// Triggered monster - takes away one life from the player
		else if (other.gameObject.CompareTag ("Monster") || other.gameObject.CompareTag ("MonsterTrigger")) {
			lostLife = true;
		} else if (other.gameObject.CompareTag ("OpenCage")) {
			GameObject cage = GameObject.FindGameObjectWithTag ("Cage");
			if (cage != null) {
				cage.GetComponent<CageController> ().StartFade ();
			}
		}
	}
}

