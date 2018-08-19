using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speed = 1.0f;
	public Vector3 direction = Vector3.zero;

	// Use this for initialization
	void Start () {
		direction.x = 0.001f * speed;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller  = GetComponent<CharacterController>();
		transform.Translate(direction.x,0,0);
		transform.Rotation(Vector3.zero);

	}
}
