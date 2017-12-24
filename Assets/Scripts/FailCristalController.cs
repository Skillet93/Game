using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailCristalController : MonoBehaviour
{
	
	// Use this for initialization
	void Start () {
		
	}
	

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.gameObject.name.Equals("Cat"))
		{
			other.gameObject.GetComponent<Animator>().SetTrigger("fail");
		}
	}
}
