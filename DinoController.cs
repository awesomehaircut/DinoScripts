using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour {
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag != "Cacti") return;
		throw new System.NotImplementedException();
	}
}
