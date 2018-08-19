using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int size;
	public int amount;
	public int frequency;
	public Vector3 spawnValue;
	public GameObject obstaclesmall;
	public GameObject obstaclemedium;
	public GameObject obstaclebig;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag("Cacti").Length < amount)
		{
			if ((Random.value) < 0.3){
				spawn_cacti(obstaclesmall);
			}
			if ((Random.value) < 0.6){
				spawn_cacti(obstaclemedium);
			}
			spawn_cacti(obstaclebig);

		}
	}
	void spawn_cacti(GameObject obstacle){
		Vector3 spawnPosition = new Vector3 (spawnValue.x, spawnValue.y, spawnValue.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (obstacle, spawnPosition, spawnRotation);
	}
}

