using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DinoController : MonoBehaviour
{
	public int Health = 3;
	public float CoolDownTimer = 0.2f;
	public GameObject Dino;

	private bool _isKeyDown;
	private bool _isJumping;
	
	

	private void Update()
	{
		if (Input.anyKey)
		{
			Jump();
			_isKeyDown = true;
		}
		if (!Input.anyKey && _isKeyDown)
		{
			_isJumping = true;
			_isKeyDown = false;
		}
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (_isJumping & other.gameObject.tag == "Floor")
		{
			Debug.Log("Touching the ground");
			_isJumping = false;
		}

		if (!other.gameObject.CompareTag("Cacti")) return;
		/// If hit by a cacti, take damage
        Damage();
	}

	private void Jump()
	{
		Debug.Log("Trying to Jump");
		if (_isJumping) return;
		Debug.Log("Jumping!");
		Dino.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.VelocityChange);
	}
	
	private void Damage()
	{
		Debug.Log("Taking a hit");
		if (Health > 1)
		{
			Health--;
			return;
		}
		Death();
	}

private static void Death()
	{
		Debug.LogWarning("Death");
		SceneManager.LoadScene("Testing");
	}
}
