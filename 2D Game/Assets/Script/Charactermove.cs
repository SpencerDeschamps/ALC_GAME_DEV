using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactermove : MonoBehaviour {

	// Player Movement Variables
	public int MoveSpeed;
	public float Jumpheight; 
	private bool DoubleJump;

	//Player grounded variation
	public Transform groundcheck;
	public float groundcheckradius;
	public LayerMask whatisground;
	private bool grounded;

	//non slide player
	private float MoveVelocity;

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, whatisground);
	}

	public Animator animator;

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
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		// Double Jump Code
		if(grounded){
			DoubleJump = false;
		
		}

		if(Input.GetKeyDown (KeyCode.W)&& !DoubleJump && !grounded){
			Jump();
			DoubleJump = true;
		}
	// Non-slide player
	MoveVelocity = 0f;

	// This code makes the character move from side to side using a&d
	if(Input.GetKey (KeyCode.D)){
		//GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		MoveVelocity = MoveSpeed;

	else if (Input.GetKeyUp (KeyCode.D)){
		animator.SetBool("IsWalking",false);

	}
	if(Input.GetKey (KeyCode.A)){
		//GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		MoveVelocity = -MoveSpeed;	
	}

	GetComponent<Rigidbody2D>().velocity = new Vector2(MoveVelocity, GetComponent<Rigidbody2D>().velocity.y);

	// player flip
	if (GetComponent<Rigidbody2D>().velocity.x >0)
		transform.localScale = new Vector3(3f, 3f, 1f);

	else if (GetComponent<Rigidbody2D>().velocity.x <0)
		transform.localScale = new Vector3(-3f, 3f, 1f);

}
	// Use this for initialization
	void Start () {
		animator.SetBool("IsWalking",false);
		animator.SetBool("IsJumping",false);
	}	
		public void Jump(){
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jumpheight);
			animator.SetBool("IsJumping",true);
		}
		
}
