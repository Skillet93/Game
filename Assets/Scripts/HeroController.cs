using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class HeroController : MonoBehaviour
{

	public float heroSpeed;
	public float jumpForce;
	public Transform groundpoint;
	public LayerMask layerToTest;
	
	
	private Animator anim;
	private Rigidbody2D rgdBody;
	private bool directionToRight = true;
	private bool onTheGround = true;
	private float radius = 0.1f;

	private int count = 0;
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		rgdBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log("Update: " + System.DateTime.Now.Millisecond);
		ActionStore.ModifyColorFactor(0.0015f);
		onTheGround = Physics2D.OverlapCircle(groundpoint.position, radius, layerToTest);
		var horizontalMove = Input.GetAxis("Horizontal");
		//Debug.Log("Move: " + horizontalMove);
		rgdBody.velocity = new Vector2(horizontalMove * heroSpeed, rgdBody.velocity.y);
		if (Input.GetKeyDown(KeyCode.Space) && onTheGround)
		{
			rgdBody.AddForce(new Vector2(0f, jumpForce));
			anim.SetTrigger("jump");
		}
		anim.SetFloat("speed", Mathf.Abs(horizontalMove));
		
		SetHeroDirection(horizontalMove);
	}

	private void SetHeroDirection(float horizontalMove)
	{
		if (horizontalMove < 0 && directionToRight)
		{
			FlipHero();
		}

		if (horizontalMove > 0 && !directionToRight)
		{
			FlipHero();
		}
	}

	private void FlipHero()
	{
		directionToRight = !directionToRight;
		var heroScale = gameObject.transform.localScale;
		heroScale.x *= -1;
		gameObject.transform.localScale = heroScale;
	}
}
