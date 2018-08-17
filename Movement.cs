using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speed = 0.001f;
	public Vector3 direction = Vector3.zero;

	// Use this for initialization
	void Start () {
		direction.x = 1 * speed;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller  = GetComponent<CharacterController>();
		transform.Translate(direction.x,0,0);
		
	}
}
