using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float x = 10f;

	// Use this for initialization
	private void Start () {
	}
	
	// Update is called once per frame
	private void Update () {
		transform.Translate(x * Time.deltaTime,0,0);
	}
}
