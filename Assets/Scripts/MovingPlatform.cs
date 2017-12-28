using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

	public float Speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Speed,0,0);	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.gameObject.name);
	}
}
