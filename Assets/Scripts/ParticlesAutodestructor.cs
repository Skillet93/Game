using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesAutodestructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("Autodestructor", 3f);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Autodestructor() 
	{
		Destroy(this.gameObject);
	}
}
