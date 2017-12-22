using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
	public Transform cameraTransform;
	public float parallaxFactor;

	private Vector3 previousCameraPosition;
	private Vector3 deltaCameraPosition;
	// Use this for initialization
	void Start ()
	{
		previousCameraPosition = cameraTransform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		deltaCameraPosition = cameraTransform.position - previousCameraPosition;
		var positionX = transform.position.x + (deltaCameraPosition.x * parallaxFactor);
		var parallaxPosition = new Vector3(positionX, transform.position.y, transform.position.z);
		transform.position = parallaxPosition;
		previousCameraPosition = cameraTransform.position;
	}
}
