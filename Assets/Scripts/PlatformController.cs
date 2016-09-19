﻿using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	private int direction = -1;
	private float xPosition;
	private float yPosition;
	[HideInInspector] public Vector3 movement;

	public float xWidth;
	public float yWidth;

	// Use this for initialization
	void Start () {
		xPosition = transform.position.x;
		yPosition = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		if (this.CompareTag ("MoveHorizontal")) {
			if (transform.position.x > (xPosition + xWidth)) {
				direction = -1;
			} else if (transform.position.x < xPosition) {
				direction = 1;
			}
			movement = Vector3.right * direction * 2.0f * Time.deltaTime;
		} else if(this.CompareTag("MoveVertical")){
			if (transform.position.y > (yPosition + yWidth)) {
				direction = -1;
			} else if(transform.position.y < yPosition){
				direction = 1;
			}
			movement = Vector3.up * direction * 2.0f * Time.deltaTime;
		}

		transform.Translate (movement);
	}





}


