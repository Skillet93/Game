using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform NavigationStartPoint;
    public Transform NavigationEndPoint;
    public float Speed;

    private Vector2 _startPoint;
    private Vector2 _endPoint;

    private Vector2 _currentPlatformPosition;

    // Use this for initialization
    void Start()
    {
        _startPoint = NavigationStartPoint.position;
        _endPoint = NavigationEndPoint.position;
        Destroy(NavigationStartPoint.gameObject);
        Destroy(NavigationEndPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        _currentPlatformPosition = Vector2.Lerp(_startPoint, _endPoint, Mathf.PingPong(Time.time * Speed, 1));
        transform.position = _currentPlatformPosition;
        //transform.Translate(Speed,0,0);	
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " - IN");
        other.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " - OUT");
        other.transform.parent = null;
    }
}