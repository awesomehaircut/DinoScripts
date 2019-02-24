using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
	public float X = 10f;
	public Rigidbody CactusRb;
	public GameObject CactusObject;

	// Use this for initialization
	private void Start () {
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			CactusRb.detectCollisions = false;
			throw new System.NotImplementedException();
		}
		
	}

	// Update is called once per frame
	private void Update () {
		transform.Translate(X * -1 * Time.deltaTime,0,0);
		if (CactusRb.position.y < -2)
		{
			Destroy(CactusObject);
		}
	}
}
