using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BackGroundController : MonoBehaviour {

	public GameObject Hero;

	private SpriteRenderer _spriteRenderer;
	// Use this for initialization
	void Start ()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log("R: "+ _spriteRenderer.color.r);
		Debug.Log("G: "+ _spriteRenderer.color.g);
		_spriteRenderer.color = new Color(ActionStore.RedFactor, ActionStore.GreenFactor,
				_spriteRenderer.color.b, _spriteRenderer.color.a);

	}
}
