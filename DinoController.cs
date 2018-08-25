using System.Collections;
using System.Collections.Generic;
using System.Net;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoController : MonoBehaviour
{
	public int Health = 3;
	public int CoolDownTimer = 1;
	private float _coolDownTime;
	private bool _isJumping;
	private bool _isCoolDown;
	public GameObject Dino;

	private void Update()
	{
		if (_isJumping) return;
        if (!Input.GetButtonDown("Jump")) return;
		Debug.Log("Jumping!");
        Dino.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
		_isJumping = true;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (_isJumping & other.gameObject.tag == "Floor")
		{
			Debug.Log("Touching the ground");
			_isJumping = false;
		}
		if (other.gameObject.tag != "Cacti") return;
		if (_isCoolDown)
		{
			Debug.Log(string.Format("CoolDownTimer is {0}", CoolDownTimer));
			if (_coolDownTime + CoolDownTimer < Time.fixedTime)
			{
				_isCoolDown = false;
				Debug.Log("CoolDown is false");
			}
			return;
		}
        Debug.Log("Taking a hit");
		if (Health > 1)
		{
			Health--;
			_isCoolDown = true;
			_coolDownTime = Time.fixedTime;
			return;
		}
		Death();
	}

	private void Death()
	{
		Debug.LogWarning("Death");
		SceneManager.LoadScene("_Scene");
	}
}

