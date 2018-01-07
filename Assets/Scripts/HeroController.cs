using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Resources;
using DefaultNamespace;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class HeroController : MonoBehaviour
{
    public float HeroSpeed;
    public float JumpForce;
    public float PowerJumpForce;
    public Transform Groundpoint;
    public LayerMask LayerToTest;
    public Transform StartPoint;
    public AudioClip JumpSound;
    
    private CounterController _counterController;
    private Animator _anim;
    private Rigidbody2D _rgdBody;
    private bool _directionToRight = true;
    private bool _onTheGround = true;
    private float _radius = 0.1f;
    private int _count = 0;
    private bool _heroDead;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rgdBody = GetComponent<Rigidbody2D>();
        _counterController = GameObject.Find("Manager").GetComponent<CounterController>();
        if (_counterController == null)
        {
            Debug.LogError("Counter controller not found.");
        }
    }

    void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("CristalContact"))
        {
            _heroDead = true;
        } else if (transform.position.y < -8f)
        {
            _heroDead = true;
            RestartHero();
        }

        if (_heroDead)
        {
            _rgdBody.velocity = Vector2.zero;
            return;
        }
        ActionStore.ModifyColorFactor(0.0015f);
        _onTheGround = Physics2D.OverlapCircle(Groundpoint.position, _radius, LayerToTest);
        _anim.SetBool("onGround", _onTheGround);
        var horizontalMove = Input.GetAxis("Horizontal");
        Debug.Log("Horizontal: "+horizontalMove);
        _rgdBody.velocity = new Vector2(horizontalMove * HeroSpeed, _rgdBody.velocity.y);
        
        ManageToJump();
        _anim.SetFloat("speed", Mathf.Abs(horizontalMove));

        SetHeroDirection(horizontalMove);
    }

    private void ManageToJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onTheGround)
        {
            SingleJump();
        } else if (Input.GetKeyDown(KeyCode.LeftControl) && _onTheGround && _counterController.IsAvailablePowerJump())
        {
            PowerJump();
        }
    }

    private void PowerJump()
    {
        _rgdBody.AddForce(new Vector2(0f, PowerJumpForce));
        _anim.SetTrigger("powerJump");
        AudioSource.PlayClipAtPoint(JumpSound, transform.position);
        _counterController.DecrementJumpCounter();
    }

    private void SingleJump()
    {
        _rgdBody.AddForce(new Vector2(0f, JumpForce));
        _anim.SetTrigger("jump");
        AudioSource.PlayClipAtPoint(JumpSound, transform.position);
    }

    private void SetHeroDirection(float horizontalMove)
    {
        if (horizontalMove < 0 && _directionToRight)
        {
            FlipHero();
        }

        if (horizontalMove > 0 && !_directionToRight)
        {
            FlipHero();
        }
    }

    private void FlipHero()
    {
        _directionToRight = !_directionToRight;
        var heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }

    public void RestartHero()
    {
        _heroDead = false;
        gameObject.transform.position = StartPoint.position;
    }
}