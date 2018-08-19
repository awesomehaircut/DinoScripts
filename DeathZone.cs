using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathZone : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag != "Cacti") return;
		Console.WriteLine("Pls");
		Destroy(other.gameObject);

	}
}