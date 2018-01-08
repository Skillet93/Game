using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

	public Transform NavigationStartPoint;
	public Transform NavigationEndPoint;
	public float HeroSpeed;

	private Animator _anim;
	private Vector2 _startPoint;
	private Vector2 _endPoint;
	private bool _directionToRight = true;
	private bool _changeDirection;
	private Rigidbody2D _rgdBody;
	private float horizontalMove;
	private Vector2 _currentPlatformPosition;
	// Use this for initialization
	void Start () 
	{
		_startPoint = NavigationStartPoint.position;
		_endPoint = NavigationEndPoint.position;
		Destroy(NavigationStartPoint.gameObject);
		Destroy(NavigationEndPoint.gameObject);
		_rgdBody = GetComponent<Rigidbody2D>();
		_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > _endPoint.x)
		{
			horizontalMove = horizontalMove*(-1) - 1.1f;
			_changeDirection = true;
			_directionToRight = !_directionToRight;
			Debug.Log("Dog position"+transform.position.x+" EdPointPosition: "+_endPoint.x);
			Debug.Log("Change direction: to left: "+_directionToRight+" HorizontalMove: "+horizontalMove);
		} else if(transform.position.x < _startPoint.x)
		{
			_changeDirection = true;
			horizontalMove = horizontalMove*(-1) + 1.1f;
			_directionToRight = !_directionToRight;
			Debug.Log("Dog position"+transform.position.x+" StartPointPosition: "+_startPoint.x);
			Debug.Log("Change direction: to right: "+_directionToRight+" HorizontalMove: "+horizontalMove);
		}
		
		if (_directionToRight && !_changeDirection && horizontalMove < 1f)
		{
			horizontalMove += 0.05f;				
			//Debug.Log("Adding horizontalMove: "+horizontalMove);
		}
		else if (!_directionToRight && !_changeDirection && horizontalMove > -1f)
		{
			horizontalMove -= 0.05f;	
			//Debug.Log("Subtract horizontalMove: "+horizontalMove);
		}

		_rgdBody.velocity = new Vector2(horizontalMove * HeroSpeed, _rgdBody.velocity.y);
		_anim.SetFloat("speed", Mathf.Abs(horizontalMove));
		SetHeroDirection(horizontalMove);
		_changeDirection = false;
	}

	public void DogDestroy()
	{
		Destroy(this.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		var hero = other.gameObject;
		if (hero.name.Equals("Cat"))
		{
			if (hero.transform.position.y > (transform.position.y + 0.67f))
			{
				GetComponent<BoxCollider2D>().enabled = false;
				gameObject.GetComponent<Animator>().SetTrigger("DogDead");
			}
			else
			{
				other.gameObject.GetComponent<Animator>().SetTrigger("fail");
			}
		}
	}

	private void SetHeroDirection(float horizontalMove)
	{
		Debug.Log("SetHeroDirection: " + horizontalMove);
		if (_changeDirection)
		{
			FlipHero();
		}
	}

	private void FlipHero()
	{
		Debug.Log("Flip Dog");
		horizontalMove = 0;
		var heroScale = gameObject.transform.localScale;
		heroScale.x *= -1;
		gameObject.transform.localScale = heroScale;
	}
}
