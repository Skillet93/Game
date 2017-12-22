using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHero : MonoBehaviour
{

	public GameObject Hero;
	public float Smooth;

	private Vector3 currentVelocity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var newCameraPosition = new Vector3(Hero.transform.position.x, transform.position.y, transform.position.z);
		transform.position = Vector3.SmoothDamp(transform.position, newCameraPosition, ref currentVelocity, Smooth);
	}
}
