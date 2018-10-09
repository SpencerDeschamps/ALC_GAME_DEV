using UnityEngine;
using System.Collections;
public class KillPlayer : MonoBehaviour {
public LevelManager LevelManager;
// Use this for initialization
void Start () {
LevelManager = FindObjectOfType <LevelManager>();
}
// Update is called once per frame
void Update () {
}

void OnTriggerEnter2D(Rigidbody2D other){
if(other.name == "PC"){
	print ("player has entered enemy trigger");
LevelManager.CurrentCheckPoint = gameObject;
		}

	}
}
