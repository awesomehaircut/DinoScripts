using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour {

	public int Amount;
	public int Frequency;
	public Vector3 SpawnValue;
	public GameObject Obstaclesmall;
	public GameObject Obstaclemedium;
	public GameObject Obstaclebig;
	
	// Use this for initialization
	private void Start()
	{
		Debug.Log("Starting");
		foreach (var cacti in GameObject.FindGameObjectsWithTag("Cacti")){
			Destroy(cacti);
			if (Debug.isDebugBuild)
			{
				throw new SystemException("This is to start the debugger");
			}
		}
	}
	
	// Update is called once per frame
	private void Update ()
	{
		int amount_of_cacti = GameObject.FindGameObjectsWithTag("Cacti").Length;
		Debug.Log("Amount of Cacti:");
		Debug.Log(amount_of_cacti);
		if (amount_of_cacti >= Amount) return;
		if (Time.timeSinceLevelLoad < Frequency ) return;
		Frequency += 1;
		Debug.Log(Time.fixedTime);
		var seed = Random.Range(1, 4);
		switch (seed)
		{
			case 1:
				Debug.Log("Spawning Big");
                spawn_cacti(Obstaclebig);
				break;
			case 2:
				Debug.Log("Spawning Medium");
                spawn_cacti(Obstaclemedium);
				break;
			default:
				Debug.Log("Spawning small");
                spawn_cacti(Obstaclesmall);
				break;
		}
	}

	private void spawn_cacti(GameObject obstacle){
		var spawnPosition = new Vector3 (SpawnValue.x, SpawnValue.y, SpawnValue.z);
		var spawnRotation = Quaternion.identity;
		Instantiate (obstacle, spawnPosition, spawnRotation);
	}
}

