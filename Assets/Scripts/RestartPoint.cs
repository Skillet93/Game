using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPoint : MonoBehaviour
{

	private RestartPointsManager _restartPointsManager;

	private SpriteRenderer _sprRenderer;
	// Use this for initialization
	void Start ()
	{
		_restartPointsManager = GameObject.Find("Manager").GetComponent<RestartPointsManager>();
		if (_restartPointsManager == null)
		{
			Debug.LogError("RestartpointsManager  not found.");
		}
		_sprRenderer = GetComponent<SpriteRenderer>();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			_restartPointsManager.UpdateStartPoint(this.transform);
			_sprRenderer.color = new Color(0.05f, 0.6f, 0.58f);
		}
	}
}
