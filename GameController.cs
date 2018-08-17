using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public float speed;
	public int size;
	public int amount;
	public int frequency;
	public GameObject obstacle;
	public Vector3 spawnValue;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag("Cacti").Length < amount)
		{
			spawn_cacti();
		}
		
	}
	void spawn_cacti(){
		Vector3 spawnPosition = new Vector3 (spawnValue.x, spawnValue.y, spawnValue.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (obstacle, spawnPosition, spawnRotation);
	}
}

