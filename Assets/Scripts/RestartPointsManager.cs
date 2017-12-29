using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestartPointsManager : MonoBehaviour
{
	public HeroController HeroController;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void UpdateStartPoint (Transform transform)
	{
		HeroController.StartPoint = transform;
	}
}
