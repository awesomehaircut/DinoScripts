using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public int x = 1;

	// Use this for initialization
	private void Start () {
	}
	
	// Update is called once per frame
	private void Update () {
		transform.Translate(-1,0,0);
	}
}
