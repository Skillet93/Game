using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCristal : MonoBehaviour
{

	private CounterController _counterController;
	public Light cristalLight;
	// Use this for initialization
	void Start ()
	{
		_counterController = GameObject.Find("Manager").GetComponent<CounterController>();
		if (_counterController == null)
		{
			Debug.LogError("Counter controller not found.");
		}
	}
	
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.gameObject.name.Equals("Cat"))
		{
			Destroy(this.gameObject);
			Destroy(cristalLight);
			_counterController.IncrementCounter();
		}
	}
}
