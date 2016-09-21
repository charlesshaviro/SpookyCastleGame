using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	[HideInInspector] public bool FacingRight = true;

	public float Speed = 1f;
	public Transform GroundCheck;

	private bool Grounded = false;
	private Rigidbody2D rb2d;

	private float xPos;
	private float yPos;
	private int direction = 1;

	private Vector3 movement;
	public float xWidth;


	// Use this for initialization
	void Awake(){
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Start(){
		xPos = transform.position.x;
		yPos = transform.position.y;
	}
		

	void Update () {

		Grounded = Physics2D.Linecast (transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		if (transform.position.x > (xPos + xWidth) && direction == 1) {
			Flip ();
			direction = -1;
		} else if (transform.position.x < xPos && direction == -1) {
			Flip ();
			direction = 1;
		} 

		movement = Vector3.right * 2.0f * Time.deltaTime;
		transform.Translate (movement);
	}

	void Flip() {

		FacingRight = !FacingRight;
		Vector3 TheScale = transform.localScale;
		TheScale.x *= -1;
		transform.localScale = TheScale;
	}

}
