using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D PC;

	// particles
	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	// Respawn delay
	public float RespawnDelay;

	// Point Penalty On Death
	public int PointPenaltyOnDeath;

	//store Gravity Value
	private float GravityStore;

	// Use this for initialization
	void Start () {
		// PC = FindObjectOfType<Rigidbody2D> ();
	}

public void RespawnPlayer(){
	StartCoroutine ("RespawnPlayerCo");
}

public IEnumerator RespawnPlayerCo(){
	// Generate death particle
	Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation);
	//hide pc
	// PC.enabled = false;
	PC.GetComponent<Renderer> ().enabled = false;
	// gravity reset
	GravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
	PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
	PC.GetComponent<Rigidbody2D>().velocity= Vector2.zero;
	//point penalty
	ScoreManager.AddPoints(-PointPenaltyOnDeath);
	//debug message
	Debug.Log ("PC Respawn");
	//respawn delay
	yield return new WaitForSeconds (RespawnDelay);
	//gravity restore
	PC.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
	//match pcs transform position
	PC.transform.position = CurrentCheckPoint.transform.position;
	//show pc
	//PC.enabled = true;
	PC.GetComponent<Renderer> ().enabled = true;
	//Spawn PC
	Instantiate (RespawnParticle, CurrentCheckPoint.transform.position,CurrentCheckPoint.transform.rotation);
}
}