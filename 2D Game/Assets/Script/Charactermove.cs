using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactermove : MonoBehaviour {

	// Player Movement Variables
	public int MoveSpeed;
	public float Jumpheight; 

	//Player grounded variation
	public Transform groundcheck;
	public float groundcheckradius;
	public LayerMask whatisground;
	private bool grounded;

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, whatisground);
	}

	// Update is called once per frame
	void Update () {
		// this code makes the character jump
		if(Input.GetKeyDown (KeyCode.W)&& grounded){
			Jump();
		}
		// This code makes the character move from side to side using a&d
		if(Input.GetKey (KeyCode.D)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		if(Input.GetKey (KeyCode.A)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.x);
		}
}
	// Use this for initialization
	void Start () {
		
	}	
		public void Jump(){
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jumpheight);
		}
}
