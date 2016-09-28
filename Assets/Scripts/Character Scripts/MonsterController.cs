using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

	[HideInInspector] public bool FacingRight = true;

	public float Speed = 1f;
	public Transform GroundCheck;


	private float xPos;
	private Vector3 originalPosition;
	private int direction = 1;

	private Vector3 movement;

	// Defines discrete interval for monster to move between
	public float xWidth;


	void Awake(){
	}

	void Start(){
		xPos = transform.position.x;
		originalPosition = transform.localPosition;
	}
		

	void Update () {
		// If moving beyond interval, turn around
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


	public void Grow(){
		transform.localScale = new Vector3 (10f, 10f, 0);
		transform.localPosition = new Vector3 (originalPosition.x, originalPosition.y + 1.0f, 0f);
		direction = 1;
		xWidth = 2f;
	}
}
