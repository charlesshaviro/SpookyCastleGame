using UnityEngine;
using System.Collections;

//Questions
// Why is he jumping as the first move?
// Jumping and trying to move sideways - how to make it so he doesn't get stuck?
// Awkward and buggy when going against movement of moving platform?
// Circle collider on bottom of hero?


public class SimplePlatformController : MonoBehaviour {

	[HideInInspector] public bool FacingRight = true;
	[HideInInspector] public bool Jump = false;

	public float MoveForce = 365f;
	public float MaxSpeed = 5f;
	public float JumpForce = 1000f;
	public Transform GroundCheck;

	private bool Grounded = false;
	//private Animator anim;
	private Rigidbody2D rb2d; 

	// Use this for initialization
	void Awake () {

		//anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Grounded = Physics2D.Linecast (transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetButtonDown ("Jump") && Grounded) {
			Jump = true;
		}
	}

	void FixedUpdate()
	{
		float H = Input.GetAxis ("Horizontal");

		//anim.SetFloat ("Speed", Mathf.Abs (H));

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
			//anim.SetTrigger("Jump");
			rb2d.AddForce( new Vector2 (0f, JumpForce));
			Jump = false;
		}
	}


	void Flip() {

		FacingRight = !FacingRight;
		Vector3 TheScale = transform.localScale;
		TheScale.x *= -1;
		transform.localScale = TheScale;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("MovingPlatform")) {
			transform.parent = other.transform;
		}else if (other.gameObject.CompareTag ("Key")) {
			int KeyNumber = other.gameObject.GetComponent<KeyController> ().KeyIndex;
			gameObject.GetComponent<Inventory>().Keys[KeyNumber] = true;
			Destroy (other.gameObject);
			Instantiate (other.gameObject, new Vector3 (0, -10, 0), Quaternion.identity);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("MovingPlatform")) {
			transform.parent = null;
		}
	}
}
