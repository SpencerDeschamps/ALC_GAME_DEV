using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CoinPickUp : MonoBehaviour {
	public int PointsToAdd;

	void OnTriggerEnter2D (Collider2D other){

			if (other.GetComponent<Rigidbody2D> () == null)
				return;

			ScoreManager.AddPoints (PointsToAdd);

			Destroy (gameObject);
		}
}	