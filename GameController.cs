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
	public int Difficulty;
	
	// Use this for initialization
	private void Start()
	{
		Debug.Log("Starting");
		foreach (var cacti in GameObject.FindGameObjectsWithTag("Cacti"))
		{
			Destroy(cacti);
		}

		if (Debug.developerConsoleVisible)
		{
			Debug.Log("Developer console on");
		}

		if (Debug.isDebugBuild) return;{
            throw new SystemException("This is to start the debugger");
        }
	}
	
	// Update is called once per frame
	private void Update()
	{
		if (Time.timeSinceLevelLoad < Frequency) return; // Only do something every so "Frequency"
		
		int amount_of_cacti = GameObject.FindGameObjectsWithTag("Cacti").Length;
//		Debug.Log(string.Format("Amount of Cacti :{0}", amount_of_cacti));
		if (amount_of_cacti >= Amount) return; // Do nothing if too many cacti are in the scene
		Frequency += 1; // Will use this as score as well as dificulty curve
//		Debug.Log(Time.fixedTime);

	/*This spawns a small, medium or large gameobject (or cacti)
	 */
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
		
		/* Speed up Cacti here */
		foreach (var cacti in GameObject.FindGameObjectsWithTag("Cacti"))
		{
			Debug.Log(string.Format("Changing the speed of :{0}", cacti));
			Movement cacti_motion = cacti.GetComponent<Movement>();
			cacti_motion.x = 6 + Frequency*Difficulty/10;
			Debug.Log(string.Format("Frequency :{0}", Frequency));
		}
	}

	private void spawn_cacti(GameObject obstacle){
        /* Uses the Spawnvalue to spawn a cacti*/		
		var spawnPosition = new Vector3 (SpawnValue.x, SpawnValue.y, SpawnValue.z);
		var spawnRotation = Quaternion.identity;
		Instantiate (obstacle, spawnPosition, spawnRotation);
	}
}

