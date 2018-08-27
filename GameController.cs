using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour {

	public int Amount;
	public int Frequency;
	public Vector3 SpawnValue;
	public GameObject Obstaclesmall;
	public GameObject Obstaclemedium;
	public GameObject Obstaclebig;
	public int Difficulty;
	public GameObject Text;
	public GameObject Dino;
	
	// Use this for initialization
	private void Start()
	{
		Debug.Log("Starting");
		Text.GetComponent<Text>().text = string.Format("\nScore: {0}\t\nHP: {1}\t", 0, 0);
		foreach (var cacti in GameObject.FindGameObjectsWithTag("Cacti"))
		{
			/* I don't understand why there's any cacti in the scene when starting the game
			 But whatever, just delete any that are left over.*/
			Destroy(cacti);
		}

		if (Debug.developerConsoleVisible)
		{
			/// I don't understand this 
			Debug.Log("Developer console on");
		}

		if (Debug.isDebugBuild) return;{
			/// TODO make rider work with the unity debugger. Or figure it out.
            throw new SystemException("This is to start the debugger");
        }
	}
	
	// Update is called once per frame
	private void Update()
	{
		if (Time.timeSinceLevelLoad < Frequency) return; // Only do something every so "Frequency"
		Text.GetComponent<Text>().text = string.Format("\nScore: {0}\t\nHP: {1}\t", Frequency, Dino.GetComponent<DinoController>().Health);
		int amount_of_cacti = GameObject.FindGameObjectsWithTag("Cacti").Length;
		if (amount_of_cacti >= Amount) return; // Do nothing if too many cacti are in the scene
		Frequency += 1; // Will use this as score as well as dificulty curve

	/*This spawns a small, medium or large gameobject (or cacti)
	 */
		var seed = Random.Range(1, 4); // Is this efficient? It probably does't matter
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

