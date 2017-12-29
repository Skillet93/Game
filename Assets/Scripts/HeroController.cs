using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float HeroSpeed;
    public float JumpForce;
    public Transform Groundpoint;
    public LayerMask LayerToTest;
    public Transform StartPoint;
    public AudioClip JumpSound;


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
    }

    void Update()
    {
        //Debug.Log("Update: " + System.DateTime.Now.Millisecond);
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("CristalContact"))
        {
            _heroDead = true;
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
        //Debug.Log("Move: " + horizontalMove);
        _rgdBody.velocity = new Vector2(horizontalMove * HeroSpeed, _rgdBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && _onTheGround)
        {
            _rgdBody.AddForce(new Vector2(0f, JumpForce));
            _anim.SetTrigger("jump");
            AudioSource.PlayClipAtPoint(JumpSound, transform.position);
        }
        _anim.SetFloat("speed", Mathf.Abs(horizontalMove));

        SetHeroDirection(horizontalMove);
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